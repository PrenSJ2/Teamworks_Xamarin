using System;
using System.IO;
using System.Threading.Tasks;
using Foundation;
using Teamworks_2.iOS;
using Teamworks_2.Models;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(ImageService))]
namespace Teamworks_2.iOS
{
    public class ImageService : IImageService
    {
        TaskCompletionSource<string> taskCompletionSource;
        UIImagePickerController imagePicker;

        public Task<string> PickImageAsync()
        {
            // Create and define UIImagePickerController
            imagePicker = new UIImagePickerController
            {
                SourceType = UIImagePickerControllerSourceType.PhotoLibrary,
                MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary)
            };

            // Set event handlers
            imagePicker.FinishedPickingMedia += OnImagePickerFinishedPickingMedia;
            imagePicker.Canceled += OnImagePickerCancelled;

            // Present UIImagePickerController;
            UIWindow window = UIApplication.SharedApplication.KeyWindow;
            var viewController = window.RootViewController;
            viewController.PresentModalViewController(imagePicker, true);

            // Return Task object
            taskCompletionSource = new TaskCompletionSource<string>();
            return taskCompletionSource.Task;
        }

        void OnImagePickerFinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs args)
        {
            // Dismiss UIImagePickerController
            imagePicker.DismissModalViewController(true);

            // Get selected image
            UIImage image = args.EditedImage ?? args.OriginalImage;
            if (image != null)
            {
                // Convert UIImage to .NET Stream object
                NSData data = image.AsJPEG(1);
                Stream stream = data.AsStream();

                // Save image to temporary file
                string tempPath = Path.GetTempFileName();
                using (FileStream fs = File.Open(tempPath, FileMode.Create))
                {
                    stream.CopyTo(fs);
                }

                // Set TaskCompletionSource result
                taskCompletionSource.SetResult(tempPath);
            }
            else
            {
                taskCompletionSource.SetResult(null);
            }
        }

        void OnImagePickerCancelled(object sender, EventArgs args)
        {
            // Dismiss UIImagePickerController
            imagePicker.DismissModalViewController(true);

            // Set TaskCompletionSource result
            taskCompletionSource.SetResult(null);
        }

    }
}
