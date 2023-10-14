package handlers

import (
	"github.com/gin-gonic/gin"
	"log"
	"science-archive/doc-store-api/internal/api/dtos"
	"science-archive/doc-store-api/internal/api/dtos/storage/response_dtos"
	"science-archive/doc-store-api/internal/core/serivces"
)

type StorageHandler struct {
	storageService serivces.StorageService
}

func NewStorageHandler(service serivces.StorageService) *StorageHandler {
	return &StorageHandler{
		storageService: service,
	}
}

func (d *StorageHandler) UploadDocument(c *gin.Context) {
	fileHeader, err := c.FormFile("document")

	if err != nil || fileHeader == nil {
		errorStr := "File could not be read or not present"

		log.Println(errorStr, err)
		c.IndentedJSON(400, dtos.Response{Success: false, Error: errorStr})
		return
	}

	file, err := fileHeader.Open()

	if err != nil {
		errorStr := "Could not read file"

		log.Println(errorStr, err)
		c.IndentedJSON(400, dtos.Response{Success: false, Error: errorStr})
		return
	}

	path, err := d.storageService.UploadDocument(file)

	if err != nil {
		errorStr := "An error occurred while uploading document"

		log.Println(errorStr, err)
		c.IndentedJSON(400, dtos.Response{Success: false, Error: errorStr})
		return
	}

	resData := &response_dtos.UploadDocumentResponse{
		Path: path,
	}

	res := dtos.Response{
		Success: true,
		Data:    resData,
	}

	c.IndentedJSON(201, res)
}
