# XamAntClientApp
This solution is a Xamarin Forms example targeting Android devices. It uses the ANT+ Class Library.
The underlying data transport is UDP with broadcast data received from a multicast port on the local subnet.

Note that the UDP protocol does not make any guarantees as to message delivery or sequence. Caveat emptor! This is just
a simple demo. I'll be providing a .NET MAUI solution in the near future that utilizes gRPC in conjunction with UDP in
the near future.
### Prerequisites
Become an ANT+ Adopter! There is no membership fee. 
Create a login and go to [Become an Adopter](https://www.thisisant.com/my-ant/join-adopter). This provides you with access to
device profiles, SDK's, and useful software tools. You'll need SimulANT+ for simulating ANT device.
- Visual Studio 2022 Community Edition or higher.
- ANT USB stick hardware and device drivers. I use two sticks, one for simulating devices, and the other for
 testing. Some example projects require it. You can get them from DigiKey for around $45 for two.
- Clone and build the [ANT+ Class Library](https://github.com/StephenHidem/AntPlus) solution.
### Quickstart
Run the AntMultiCastServer console app located in the ANT+ Class Library examples after building that solution. Build
and deploy this solution to an Android device (sorry, I don't have the hardware to run on iOS). Run SimulANT+ and
select a device to simulate (i.e. asset tracker, bike power, etc.). You should see the device listed on your Android
device. Tap on the device to get additional details and commands that can be sent to the device.
