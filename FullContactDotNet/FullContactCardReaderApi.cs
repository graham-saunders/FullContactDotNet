﻿using FullContactDotNet.CardReader;
using FullContactDotNet.Shared;
using RestSharp;
using System;

namespace FullContactDotNet
{
    public class FullContactCardReaderApi : FullContactApi, IFullContactCardReaderApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FullContactCardReaderApi"/> class.
        /// </summary>
        public FullContactCardReaderApi() : base(FullContactConfiguration.ApiKey) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="FullContactCardReaderApi"/> class.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        public FullContactCardReaderApi(string apiKey) : base(apiKey) { }

        /// <summary>
        /// Uploads the card.
        /// </summary>
        /// <param name="frontBase64Encoded">The front base64 encoded.</param>
        /// <param name="backBase64Encoded">The back base64 encoded.</param>
        /// <param name="webhookUrl">The webhook URL.</param>
        /// <param name="casing">The casing.</param>
        /// <param name="sandbox">The sandbox.</param>
        /// <returns></returns>
        public CardReaderResponse UploadCard(
            string frontBase64Encoded,
            string backBase64Encoded,
            string webhookUrl,
            Casing? casing = null,
            SandboxMode? sandbox = null)
        {
            if (string.IsNullOrWhiteSpace(frontBase64Encoded)) throw new ArgumentNullException("frontBase64Encoded", "A front image is required to process a card.");

            var request = GetCardReaderRequest(webhookUrl, casing, sandbox);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { front = frontBase64Encoded, back = backBase64Encoded });
            return Execute<CardReaderResponse>(request);
        }

        /// <summary>
        /// Uploads the card.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="webhookUrl">The webhook URL.</param>
        /// <param name="casing">The casing.</param>
        /// <param name="sandbox">The sandbox.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">A webhook is required to process a card.</exception>
        public CardReaderResponse UploadCard(
            byte[] front,
            byte[] back,
            string webhookUrl,
            Casing? casing = null,
            SandboxMode? sandbox = null)
        {
            if (front == null || front.Length == 0) throw new ArgumentNullException("front", "A front image is required to process a card.");

            var request = GetCardReaderRequest(webhookUrl, casing, sandbox);
            request.AddFile("front", front, "front.png|jpg|gif", "image/png|jpg|gif");

            if (back != null && back.Length > 0)
            {
                request.AddFile("back", back, "back.png|jpg|gif", "image/png|jpg|gif");
            }

            return Execute<CardReaderResponse>(request);
        }

        /// <summary>
        /// Gets the card reader request.
        /// </summary>
        /// <param name="webhookUrl">The webhook URL.</param>
        /// <param name="casing">The casing.</param>
        /// <param name="sandbox">The sandbox.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">A webhook is required to process a card.</exception>
        private RestRequest GetCardReaderRequest(
            string webhookUrl,
            Casing? casing = null,
            SandboxMode? sandbox = null)
        {
            if (string.IsNullOrWhiteSpace(webhookUrl)) throw new ArgumentNullException("webhookUrl", "A webhook is required to process a card.");

            var request = new RestRequest("/cardReader.json", Method.POST);
            request.AddQueryParameter("webhookUrl", webhookUrl);

            if (sandbox.HasValue)
            {
                request.AddQueryParameter("sandbox", sandbox.Value.ToString());
            }

            if (casing.HasValue)
            {
                request.AddQueryParameter("casing", casing.Value.ToString());
            }

            return request;
        }
    }
}
