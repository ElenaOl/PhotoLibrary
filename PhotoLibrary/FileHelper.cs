﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace PhotoLibrary
{
    //class static, all methods static
    public static class FileHelper
    {
        /// <summary>
        /// Write content to the file
        /// </summary>
        /// <param name="filename">Name of the file</param>
        /// <param name="content">Content to write to the file</param>
        public static async void WriteTextFileAsync(string filename, string content)
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            var textFile = await localFolder.CreateFileAsync
                (filename, CreationCollisionOption.OpenIfExists);


     
                await FileIO.WriteTextAsync(textFile, content);


        }

        public static async Task<string> ReadTextFileAsync(string filename)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile textFile = await localFolder.GetFileAsync(filename);
            var textStream = await textFile.OpenReadAsync();
            var textReader = new DataReader(textStream);
            var textLength = textStream.Size;
            await textReader.LoadAsync((uint)textLength);
            return textReader.ReadString((uint)textLength);
        }
    }
}
