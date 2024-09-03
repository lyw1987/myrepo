FROM golang:1.23-alphine3.20 AS Builder

LABEL maintainer="SRC"

WORKDIR /src

COPY go.* .
COPY main.go .

RUN CGO_ENABLED=0 go build -o main main.go

FROM alphine3.20

LABEL maintainer="chuk"

WORKDIR /app

COPY --from=builder /src/main .


