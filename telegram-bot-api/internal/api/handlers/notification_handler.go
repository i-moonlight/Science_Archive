package handlers

import (
	"net/http"
	"science-archive/telegram-bot-api/internal/domain/services"
)

type NotificationHandler struct {
	notificationService services.NotificationService
}

func NewNotificationHandler(ns services.NotificationService) *NotificationHandler {
	return &NotificationHandler{
		notificationService: ns,
	}
}

func (n *NotificationHandler) HandleNotifyAboutNews(res http.ResponseWriter, req *http.Request) {

}

func (n *NotificationHandler) HandleNotifyAboutArticles(res http.ResponseWriter, req *http.Request) {

}
