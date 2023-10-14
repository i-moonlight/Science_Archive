package services

// NotificationService is used to send notifications to users
type NotificationService interface {
	// NotifyAboutNews is used to notify users about new news
	NotifyAboutNews() error

	// NotifyAboutArticles is used to notify users about new articles
	NotifyAboutArticles() error
}
