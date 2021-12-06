<script lang="ts">
    import { apiUrl } from '../config'
    import type { User } from './models'
    import AddUserForm from './AddUserForm.svelte'

    let getUserPromise = get()

    async function get(){
        let response = await fetch(apiUrl + '/user')
        return await response.json()        
    }

    async function add(firstname: string, lastname: string){
        await fetch(apiUrl + '/user', { 
            method: 'POST',
            body: JSON.stringify({firstname, lastname}),
            headers: { 'Content-Type': 'application/json'}
        })
        getUserPromise = get()
    }

    async function remove(user: User){
        await fetch(apiUrl + '/user', { 
            method: 'DELETE',
            body: JSON.stringify(user),
            headers: { 'Content-Type': 'application/json'}
        })
        getUserPromise = get()
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
            {#if users.length > 0}
                {#each users as user}
                    <tr>
                        <td>{user.id}</td>
                        <td>{user.firstname}</td>
                        <td>{user.lastname}</td>
                        <td><div class='delete-btn' on:click={() => remove(user)}>x</div></td>
                    </tr>
                {/each}
            {:else}
                <tr>
                    <td colspan='3'><br><i>No user yet. Add your first user above.</i></td>
                </tr>
            {/if}
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