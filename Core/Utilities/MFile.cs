﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities
{
    public class MFile
    {


        /// <summary>
        /// آدرسی که باید در آن فایل مورد نظر ذخیره شود
        /// </summary>
        public string FilePath { get; set; }






        /// <summary>
        /// ذخیره یک عکس
        /// </summary>
        /// <returns></returns>
        public static async Task<string> Save(IFormFile uploadFile, string whereSave)
        {
            //======================================================
            string UniqueFileName, FilePath;
            

            //======================================================

            if (uploadFile != null)
            {
                UniqueFileName = GetUniqueFileName(uploadFile.FileName);
                FilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/" + whereSave, UniqueFileName);
                FileStream d = new FileStream(FilePath, FileMode.Create);
                await uploadFile.CopyToAsync(d);
                d.Close();
                return whereSave + "/" + UniqueFileName;
            }

            return String.Empty;
        }


        public static async Task Delete(string address)
        {
            var pic = Path.Combine(
                     Directory.GetCurrentDirectory(), "wwwroot\\",
                     address);
            File.Delete(pic);
        }

        private static string GetUniqueFileName(string fileName)
        {
            return Guid.NewGuid().ToString() + Path.GetExtension(fileName);
        }

    }
}
