﻿using System;
using WannaChain.Core;
using WannaChain.Core.Contracts.Implement;
using WannaChain.Core.Contracts.Implements;
using WannaChain.Core.Protocol.Sockets;
using WannaChain.Core.Wrappers;

namespace WannaChain.App
{
    class Program
    {

        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            var port = 2345;

            if (args.Length > 0)
            {
                port = Int32.Parse(args[0]);
            }

            var blockContract = new CryptoBlockContract<string>();
            var dataContract = new AnyDataContract<string>();

            var node = new WannaChainNode<string>(dataContract, blockContract);
            var listener = new SocketListener(port);
            var server = new ServerNode<string>(listener, node);

            server.Start();
        }
    }
}
