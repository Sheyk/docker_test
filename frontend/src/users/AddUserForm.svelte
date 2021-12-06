<script lang='ts'>
    export let add: (firstname: string, lastname: string) => void

    let firstname = ''
    let lastname = ''
</script>

<div class='form-container'>
    <div>
        <label for='firstname'>Firstname</label>
        <input name='firstname' bind:value={firstname} placeholder="John"/>
    </div>
    <div>
        <label for='lastname'>Lastname</label>
        <input name='lastname' bind:value={lastname} placeholder="Doe"/>
    </div>
    <button disabled={!firstname || !lastname} on:click={() => add(firstname, lastname)}>Add User</button>
</div>

<style>
    .form-container {
        display: flex;
        align-items: flex-end;
    }

    button {
        height: 2.60em;
    }

    input {
        height: 2.60em; 
    }
</style>