// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SimpleServer.cs" company="Exit Games GmbH">
//   Copyright (c) Exit Games GmbH.  All rights reserved.
// </copyright>
// <summary>
//   Example application to show how to extend the Lite application.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SimpleServer
{
    using System.IO;
    using ExitGames.Logging;
    using log4net.Config;
    using Photon.SocketServer;
    using ExitGames.Logging.Log4Net;
    /// <summary>
    ///   Example application to show how to extend the Lite application.
    /// </summary>
    public class SimpleServer : ApplicationBase
    {
        private static readonly ILogger Log = LogManager.GetCurrentClassLogger();

        protected override PeerBase CreatePeer(InitRequest initRequest)
        {
            return new SimplePeer(initRequest.Protocol, initRequest.PhotonPeer, Log);
        }

        protected override void Setup()
        {

            log4net.GlobalContext.Properties["Photon:ApplicationLogPath"] = Path.Combine(this.ApplicationRootPath, "log");

            // log4net
            string path = Path.Combine(this.BinaryPath, "log4net.config");
            var file = new FileInfo(path);
            if (file.Exists)
            {
                ExitGames.Logging.LogManager.SetLoggerFactory(Log4NetLoggerFactory.Instance);
                XmlConfigurator.ConfigureAndWatch(file);
            }

            Log.InfoFormat("Created application Instance: type={0}", Instance.GetType());
            Initialize();
        }

        protected void Initialize()
        {
            Protocol.AllowRawCustomValues = true;
        }

        protected override void TearDown()
        {

        }
    }
}