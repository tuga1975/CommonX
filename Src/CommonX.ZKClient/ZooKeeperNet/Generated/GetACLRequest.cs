// File generated by hadoop record compiler. Do not edit.
/**
* Licensed to the Apache Software Foundation (ASF) under one
* or more contributor license agreements.  See the NOTICE file
* distributed with this work for additional information
* regarding copyright ownership.  The ASF licenses this file
* to you under the Apache License, Version 2.0 (the
* "License"); you may not use this file except in compliance
* with the License.  You may obtain a copy of the License at
*
*     http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using System.IO;
using System.Text;
using CommonX.Logging;
using Org.Apache.Jute;
using ZooKeeperNet.IO;

namespace Org.Apache.Zookeeper.Proto
{
    public class GetACLRequest : IRecord, IComparable
    {
        private static readonly ILogger log;//;
        //private static readonly ILogger log;// = Scope.Resolve<ILoggerFactory>().Create(typeof (GetACLRequest));

        public GetACLRequest()
        {
        }

        public GetACLRequest(
            string path
            )
        {
            Path = path;
        }

        public string Path { get; set; }

        public int CompareTo(object obj)
        {
            var peer = (GetACLRequest) obj;
            if (peer == null)
            {
                throw new InvalidOperationException("Comparing different types of records.");
            }
            var ret = 0;
            ret = Path.CompareTo(peer.Path);
            if (ret != 0) return ret;
            return ret;
        }

        public void Serialize(IOutputArchive a_, string tag)
        {
            a_.StartRecord(this, tag);
            a_.WriteString(Path, "path");
            a_.EndRecord(this, tag);
        }

        public void Deserialize(IInputArchive a_, string tag)
        {
            a_.StartRecord(tag);
            Path = a_.ReadString("path");
            a_.EndRecord(tag);
        }

        public override string ToString()
        {
            try
            {
                var ms = new MemoryStream();
                using (var writer =
                    new EndianBinaryWriter(EndianBitConverter.Big, ms, Encoding.UTF8))
                {
                    var a_ =
                        new BinaryOutputArchive(writer);
                    a_.StartRecord(this, string.Empty);
                    a_.WriteString(Path, "path");
                    a_.EndRecord(this, string.Empty);
                    ms.Position = 0;
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            return "ERROR";
        }

        public void Write(EndianBinaryWriter writer)
        {
            var archive = new BinaryOutputArchive(writer);
            Serialize(archive, string.Empty);
        }

        public void ReadFields(EndianBinaryReader reader)
        {
            var archive = new BinaryInputArchive(reader);
            Deserialize(archive, string.Empty);
        }

        public override bool Equals(object obj)
        {
            var peer = (GetACLRequest) obj;
            if (peer == null)
            {
                return false;
            }
            if (ReferenceEquals(peer, this))
            {
                return true;
            }
            var ret = false;
            ret = Path.Equals(peer.Path);
            if (!ret) return ret;
            return ret;
        }

        public override int GetHashCode()
        {
            var result = 17;
            int ret = GetType().GetHashCode();
            result = 37*result + ret;
            ret = Path.GetHashCode();
            result = 37*result + ret;
            return result;
        }

        public static string Signature()
        {
            return "LGetACLRequest(s)";
        }
    }
}