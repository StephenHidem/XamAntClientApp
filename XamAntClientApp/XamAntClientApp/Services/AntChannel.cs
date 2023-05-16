using SmallEarthTech.AntRadioInterface;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Xml;

namespace XamAntClientApp.Services
{
    internal class AntChannel : IAntChannel
    {
        private readonly UdpClient client;
        private IPEndPoint epAddr;

        public event EventHandler<AntResponse> ChannelResponse;

        public AntChannel(UdpClient udpClient)
        {
            client = udpClient;
            Task.Run(async () =>
            {
                while (true)
                {
                    var result = await udpClient.ReceiveAsync();

                    // save the remote endpoint in case we send messages to it
                    epAddr = result.RemoteEndPoint;

                    MemoryStream ms = new MemoryStream(result.Buffer);
                    XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(ms, new XmlDictionaryReaderQuotas());
                    DataContractSerializer dcs = new(typeof(AntResponse));
                    AntResponse response = dcs.ReadObject(reader) as AntResponse;
                    if (response != null) { ChannelResponse?.Invoke(this, response); }
                }
            });
        }

        public bool AssignChannel(ChannelType channelTypeByte, byte networkNumber, uint responseWaitTime)
        {
            throw new NotImplementedException();
        }

        public bool AssignChannelExt(ChannelType channelTypeByte, byte networkNumber, ChannelTypeExtended extAssignByte, uint responseWaitTime)
        {
            throw new NotImplementedException();
        }

        public bool CloseChannel(uint responseWaitTime)
        {
            throw new NotImplementedException();
        }

        public bool ConfigFrequencyAgility(byte freq1, byte freq2, byte freq3, uint responseWaitTime)
        {
            throw new NotImplementedException();
        }

        public bool IncludeExcludeListAddChannel(ChannelId channelId, byte listIndex, uint responseWaitTime)
        {
            throw new NotImplementedException();
        }

        public bool IncludeExcludeListConfigure(byte listSize, bool isExclusionList, uint responseWaitTime)
        {
            throw new NotImplementedException();
        }

        public bool OpenChannel(uint responseWaitTime)
        {
            throw new NotImplementedException();
        }

        public ChannelId RequestChannelID(uint responseWaitTime)
        {
            throw new NotImplementedException();
        }

        public ChannelStatus RequestStatus(uint responseWaitTime)
        {
            throw new NotImplementedException();
        }

        public MessagingReturnCode SendAcknowledgedData(byte[] data, uint ackWaitTime)
        {
            throw new NotImplementedException();
        }

        public bool SendBroadcastData(byte[] data)
        {
            throw new NotImplementedException();
        }

        public MessagingReturnCode SendBurstTransfer(byte[] data, uint completeWaitTime)
        {
            throw new NotImplementedException();
        }

        public MessagingReturnCode SendExtAcknowledgedData(ChannelId channelId, byte[] data, uint ackWaitTime)
        {
            byte[] msg = BitConverter.GetBytes(channelId.Id).Concat(data).Concat(BitConverter.GetBytes(ackWaitTime)).ToArray();
            int sent = client.Send(msg, msg.Length, epAddr);
            return sent == msg.Length ? MessagingReturnCode.Pass : MessagingReturnCode.Fail;
        }

        public bool SendExtBroadcastData(ChannelId channelId, byte[] data)
        {
            throw new NotImplementedException();
        }

        public MessagingReturnCode SendExtBurstTransfer(ChannelId channelId, byte[] data, uint completeWaitTime)
        {
            throw new NotImplementedException();
        }

        public bool SetChannelFreq(byte RFFreqOffset, uint responseWaitTime)
        {
            throw new NotImplementedException();
        }

        public bool SetChannelID(ChannelId channelId, uint responseWaitTime)
        {
            throw new NotImplementedException();
        }

        public bool SetChannelID_UsingSerial(ChannelId channelId, uint waitResponseTime)
        {
            throw new NotImplementedException();
        }

        public bool SetChannelPeriod(ushort messagePeriod_32768unitspersecond, uint responseWaitTime)
        {
            throw new NotImplementedException();
        }

        public bool SetChannelSearchTimeout(byte searchTimeout, uint responseWaitTime)
        {
            throw new NotImplementedException();
        }

        public bool SetChannelTransmitPower(TransmitPower transmitPower, uint responseWaitTime)
        {
            throw new NotImplementedException();
        }

        public bool SetLowPrioritySearchTimeout(byte lowPriorityTimeout, uint responseWaitTime)
        {
            throw new NotImplementedException();
        }

        public bool SetProximitySearch(byte thresholdBin, uint responseWaitTime)
        {
            throw new NotImplementedException();
        }

        public bool SetSearchThresholdRSSI(byte thresholdRSSI, uint responseWaitTime)
        {
            throw new NotImplementedException();
        }

        public bool UnassignChannel(uint responseWaitTime)
        {
            throw new NotImplementedException();
        }
    }
}
