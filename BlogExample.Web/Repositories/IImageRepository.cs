﻿namespace BlogExample.Web.Repositories
{
    public interface IImageRepository
    {
        Task<string> UploadAsync(IFormFile formFile);
    }
}
