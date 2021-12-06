<script lang="ts">
    import { apiUrl } from '../config'
    import type { User } from './models'
    import AddUserForm from './AddUserForm.svelte'

    let getUserPromise = getUsers()

    async function getUsers(){
        let response = await fetch(apiUrl + '/user')
        return await response.json()        
    }

    function remove(user: User){
        let users = []
        let index = users.indexOf(user)
        users.splice(index, 1)
        users = users
    }

    function add(firstname: string, lastname: string){
        let users = []
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
        {#await getUserPromise}
            <tr>
                <td colspan='3'><br><i>Fetching users data...</i></td>
            </tr>
        {:then users}
            {#each users as user}
                <tr>
                    <td>{user.id}</td>
                    <td>{user.firstname}</td>
                    <td>{user.lastname}</td>
                    <td><div class='delete-btn' on:click={() => remove(user)}>x</div></td>
                </tr>
            {/each}
        {:catch error}
            <tr>
                <td colspan='3'><br><i>Could not fetch user datas: {error}</i></td>
            </tr>
        {/await}
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