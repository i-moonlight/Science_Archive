package services

import "science-archive/telegram-bot-api/internal/domain/models"

// WebhookService is used to handle webhook requests
type WebhookService interface {
	// ProcessUpdate process update message from Telegram webhook
	ProcessUpdate(u *models.TelegramUpdate) error
}
