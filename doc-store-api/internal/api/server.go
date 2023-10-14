package api

import (
	"github.com/gin-gonic/gin"
	"science-archive/doc-store-api/internal/config"
)

// Server is an HTTP server
type Server struct {
	listenAddress string
}

// NewServer creates new instance of HTTP server
func NewServer(listenAddress string) *Server {
	return &Server{
		listenAddress: listenAddress,
	}
}

// Start launches an HTTP server
func (s *Server) Start() error {
	router := gin.Default()
	s.configureRouter(router)

	return router.Run(s.listenAddress)
}

// configureRouter set up router for HTTP server
func (s *Server) configureRouter(r *gin.Engine) {
	handler := config.ConfigureHandlers()

	// Map HTTP paths to handler functions
	r.POST("api/documents/upload", handler.UploadDocument)
}
