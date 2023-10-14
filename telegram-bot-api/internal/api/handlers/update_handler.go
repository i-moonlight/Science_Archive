package handlers

import (
	"encoding/json"
	"fmt"
	"net/http"
	"science-archive/telegram-bot-api/internal/domain/models"
	"science-archive/telegram-bot-api/internal/domain/services"
)

type TelegramWebhookHandler struct {
	webhookService services.WebhookService
}

func NewTelegramWebhookHandler(ws services.WebhookService) *TelegramWebhookHandler {
	return &TelegramWebhookHandler{
		webhookService: ws,
	}
}

func (twh *TelegramWebhookHandler) HandleUpdate(res http.ResponseWriter, req *http.Request) {
	update := &models.TelegramUpdate{}

	if err := json.NewDecoder(req.Body).Decode(update); err != nil {
		fmt.Println("Could not decode request body")
		return
	}

	if err := twh.webhookService.ProcessUpdate(update); err != nil {
		fmt.Println("Could not process webhook update webhook")
		return
	}
}
