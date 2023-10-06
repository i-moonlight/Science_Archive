package main

import (
	"net/http"
	"science-archive/telegram-bot-api/internal/api/handlers"
	"science-archive/telegram-bot-api/internal/application/services"
)

func main() {
	webhookService := services.NewTelegramWebhookService()
	webhookHandler := handlers.NewTelegramWebhookHandler(webhookService)

	http.HandleFunc("/tg-bot-api", webhookHandler.HandleUpdate)

	http.ListenAndServe(":4200", nil)
}
