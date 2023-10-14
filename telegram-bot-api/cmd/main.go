package main

import (
	"net/http"
	"science-archive/telegram-bot-api/internal/api/handlers"
	"science-archive/telegram-bot-api/internal/application/services"
)

func main() {
	// Services initialization
	webhookService := services.NewTelegramWebhookService()
	notificationService := services.NewTelegramNotificationService()

	// HTTP handlers initialization
	webhookHandler := handlers.NewTelegramWebhookHandler(webhookService)
	notificationHandler := handlers.NewNotificationHandler(notificationService)

	http.HandleFunc("/tg-bot-api/webhook", webhookHandler.HandleUpdate)
	http.HandleFunc("/tg-bot-api/notify-new-news", notificationHandler.HandleNotifyAboutNews)
	http.HandleFunc("/tg-bot-api/notify-new-article", notificationHandler.HandleNotifyAboutArticles)

	http.ListenAndServe(":4200", nil)
}
