package services

import (
	"net/http"
	"net/url"
	"science-archive/telegram-bot-api/internal/domain/models"
	"science-archive/telegram-bot-api/pkg/config"
	"strconv"
)

type TelegramWebhookService struct {
	baseTelegramApi string
}

func NewTelegramWebhookService() *TelegramWebhookService {
	telegramApi := config.GetBaseTelegramApi()

	return &TelegramWebhookService{
		baseTelegramApi: telegramApi,
	}
}

func (tws *TelegramWebhookService) ProcessUpdate(u *models.TelegramUpdate) error {
	telegramApi := tws.baseTelegramApi + "/sendMessage"
	_, err := http.PostForm(
		telegramApi,
		url.Values{
			"chat_id": {strconv.Itoa(int(u.Message.Chat.ID))},
			"text":    {"Hello! I'm Science Archive Bot.\nI will notify you about all news happened in our project!"},
		},
	)

	if err != nil {
		return err
	}

	return nil
}
