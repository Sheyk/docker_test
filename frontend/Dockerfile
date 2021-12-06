FROM node:16-alpine

WORKDIR /app

COPY rollup.config.js ./
COPY package*.json ./

RUN npm ci

COPY . .

RUN npm run build

EXPOSE 5000

CMD [ "node", "run", "docker-dev" ]