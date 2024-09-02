# set build arugment
#ARG NODE_VERSION = 22

# pickup the server enviroment
FROM javascript-node:20

# how to build
# create a directory /app and cd /app
WORKDIR /app

# inside /app
# copy my src
# copy from local container
COPY main.js .
COPY package*.json .
COPY public public
COPY views views
cd 
# install node modules
RUN npm ci

# how to run
ENV APP_PORT=3000

# what are the exposed port
# EXPOSE ${port}/tcp or ${port}/udp 
EXPOSE ${APP_PORT}

# run the application 
# use entry point or command (entry point prior to command)
ENTRYPOINT javascript main
