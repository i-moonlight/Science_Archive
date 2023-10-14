package config

import "os"

func GetBaseTelegramApi() string {
	botToken := getBotToken()
	return "https://api.telegram.org/bot" + botToken
}

func getBotToken() string {
	return os.Getenv("TELEGRAM_BOT_TOKEN")
}
