# Docker Test App

This app runs with docker and contains the following components:
- frontend - [SvelteJS](https://svelte.dev/)
- backend - [F#](https://fsharp.org/)
- database - [PostgreSQL](https://www.postgresql.org/)

## Requirements

- [Docker](https://www.docker.com/)
- [Git](https://git-scm.com/)

## Setup

To start the environment, run the following command in the project folder:

```sh
docker-compose up
```

Wait for the containers to initialize (the first time may take a few minutes).

You're done!

The apps run on the following addresses:
- frontend - http://localhost:8080/
- backend - http://localhost:5000/
- database - http://localhost:5432/