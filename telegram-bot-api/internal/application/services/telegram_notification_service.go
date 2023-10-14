package services

type TelegramNotificationService struct{}

func NewTelegramNotificationService() *TelegramNotificationService {
	return &TelegramNotificationService{}
}

func (t *TelegramNotificationService) NotifyAboutNews() error {
	return nil
}

func (t *TelegramNotificationService) NotifyAboutArticles() error {
	return nil
}
