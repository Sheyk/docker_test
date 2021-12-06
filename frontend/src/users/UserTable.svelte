<script lang="ts">
    import { onMount } from 'svelte'
    import { apiUrl } from '../config'
    import type { User } from './models'
    import AddUserForm from './AddUserForm.svelte'

    let users = []

    onMount(async () => {
        await fetch(apiUrl + '/user')
            .then(r => r.json())
            .then(data => users = data)
    })

    function remove(user: User){
        let index = users.indexOf(user)
        users.splice(index, 1)
        users = users
    }

    function add(firstname: string, lastname: string){
        let id = Math.max(...users.map(x => x.id)) + 1
        users.push({ id, firstname, lastname })
        users = users
    }
</script>

<br>
<AddUserForm {add} />
<br>
<table>
    <thead>
        <tr>
            <th class='id-column'>Id</th>
            <th>Firstname</th>
            <th>Lastname</th>
            <th class='action-column'></th>
        </tr>
    </thead>
    <tbody>
        {#each users as user}
            <tr>
                <td>{user.id}</td>
                <td>{user.firstname}</td>
                <td>{user.lastname}</td>
                <td><div class='delete-btn' on:click={() => remove(user)}>x</div></td>
            </tr>
        {/each}
    </tbody>
</table>

<style>
    .delete-btn {
        color: red;
        cursor: pointer;
        width: 1.5em;
        height: 1em;
    }

    .delete-btn:hover {
        color: rosybrown;
    }

    .id-column {
        width: 4em;
    }

    .action-column {
        width: 2em
    }
</style>