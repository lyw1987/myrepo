FROM node:19

WORKDIR /app

ADD config config
ADD public public
ADD views views
ADD main.js .
ADD package.json .
ADD package-lock.json .

RUN npm ci

ENV APP_PORT=3000
ENV DB_HOST=notset DB_PORT=3306 DB_USER=fred DB_PASSWORD=fred

EXPOSE ${APP_PORT}

ENTRYPOINT node main
