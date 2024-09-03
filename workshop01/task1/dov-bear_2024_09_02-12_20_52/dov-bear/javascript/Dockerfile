# set build arugment
#ARG NODE_VERSION = 22

# pickup the server environment
FROM node:22

# create a directory /app and cd /app
WORKDIR /app

# inside /app
# copy my src
# copy from local container
COPY main.js .
COPY package*.json .
COPY public public
COPY views views

# install node modules
RUN npm ci

# set enivronment variables
ENV APP_PORT=3000 INSTANCE_NAME="Test" INSTANCE_HASH="TestHash"

# version 2 with health added
HEALTHCHECK --interval=30s --timeout=5s --start-period=5s --retries=3 \
    CMD curl -s localhost:${APP_PORT}/healthz || exit

# what are the exposed port
# Format : EXPOSE ${port}/tcp or ${port}/udp 
EXPOSE ${APP_PORT}

# run the application 
# use entry point or command (entry point prior to command)
ENTRYPOINT node main
