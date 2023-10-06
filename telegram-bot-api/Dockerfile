FROM golang:1.20
WORKDIR /app

COPY go.mod ./
RUN go mod download

COPY . .
RUN go build -o /tg-bot-api ./cmd

ARG TELEGRAM_BOT_TOKEN
ENV TELEGRAM_BOT_TOKEN=$TELEGRAM_BOT_TOKEN

EXPOSE 4200
CMD ["/tg-bot-api"]