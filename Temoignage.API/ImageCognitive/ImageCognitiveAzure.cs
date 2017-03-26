using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;
using System.IO;

namespace Temoignage.API.ImageCognitive
{
    public class ImageCognitiveAzure
    {
       
       static AnalysisResult analysisResult;

        private static string adr =
            "https://westus.api.cognitive.microsoft.com/vision/v1.0/analyze?visualFeatures=Description,Tags&subscription-key=<ca27337090734f55b0f610fb14c9909c>";

        public static void CallCognitiveService(string imagePath)
        {
          var  features = new VisualFeature[] { VisualFeature.Tags, VisualFeature.Description };

            using (var fs = new FileStream(@"C:\Vision\Sample.jpg", FileMode.Open))
            {
                //analysisResult = await visionClient.AnalyzeImageAsync(fs, features);
            }
        }
         
    }
}