package services

import "science-archive/telegram-bot-api/internal/domain/entities"

type WebhookService interface {
	// ProcessUpdate process update message from Telegram webhook
	ProcessUpdate(u *entities.TelegramUpdate) error
}
