package services

import (
	"net/http"
	"net/url"
	"os"
	"science-archive/telegram-bot-api/internal/domain/entities"
	"strconv"
)

type TelegramWebhookService struct{}

func NewTelegramWebhookService() *TelegramWebhookService {
	return &TelegramWebhookService{}
}

func (tws *TelegramWebhookService) ProcessUpdate(u *entities.TelegramUpdate) error {
	telegramApi := "https://api.telegram.org/bot" + os.Getenv("TELEGRAM_BOT_TOKEN") + "/sendMessage"
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
