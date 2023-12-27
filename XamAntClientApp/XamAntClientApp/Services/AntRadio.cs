using SmallEarthTech.AntRadioInterface;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace XamAntClientApp.Services
{
    internal class AntRadio : IAntRadio
    {
        private readonly UdpClient client = new UdpClient(55436, AddressFamily.InterNetworkV6);
        private readonly IPAddress grpAddr = IPAddress.Parse("FF02::1");
        private readonly AntChannel channel;

        public AntRadio()
        {
            // join a multicast group
            client.JoinMulticastGroup(grpAddr);
            channel = new AntChannel(client);
        }

        public int NumChannels => 8;

        public FramerType OpenedFrameType => throw new NotImplementedException();

        public PortType OpenedPortType => throw new NotImplementedException();

        public uint SerialNumber => throw new NotImplementedException();

        public event EventHandler<AntResponse> RadioResponse;

        public void CancelTransfers(int cancelWaitTime)
        {
            throw new NotImplementedException();
        }

        public IAntChannel GetChannel(int num)
        {
            return channel;
        }

        public DeviceCapabilities GetDeviceCapabilities()
        {
            throw new NotImplementedException();
        }

        public DeviceCapabilities GetDeviceCapabilities(bool forceNewCopy, uint responseWaitTime)
        {
            throw new NotImplementedException();
        }

        public DeviceCapabilities GetDeviceCapabilities(uint responseWaitTime)
        {
            throw new NotImplementedException();
        }

        public Task<IAntChannel[]> InitializeContinuousScanMode()
        {
            return Task.FromResult(new IAntChannel[] { channel, channel });
        }

        public AntResponse ReadUserNvm(ushort address, byte size)
        {
            throw new NotImplementedException();
        }

        public AntResponse ReadUserNvm(ushort address, byte size, uint responseWaitTime)
        {
            throw new NotImplementedException();
        }

        public AntResponse RequestMessageAndResponse(byte channelNum, RequestMessageID messageID, uint responseWaitTime)
        {
            throw new NotImplementedException();
        }

        public AntResponse RequestMessageAndResponse(RequestMessageID messageID, uint responseWaitTime)
        {
            throw new NotImplementedException();
        }

        public bool WriteRawMessageToDevice(byte msgID, byte[] msgData)
        {
            throw new NotImplementedException();
        }
    }
}
