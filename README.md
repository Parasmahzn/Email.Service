A Background windows service for sending email at a regular interval of time.
Creating Worker Service Command:

1.  sc create {WindowsServiceName} binpath="{FullPathToExeFile}" start="demand" displayname="{DisplayName}" 
 
// {WindowsServiceName} = Unique identifier of the Windows Service. // e.g. WorkerServiceExample
// {WindowsServiceName} = A custom name for our Windows Service
// {FullPathToExeFile} = The full path to where the executable (.exe) file of our published Worker Service project
// {DisplayName} = A friendly name for our Windows Service // e.g. Worker Service Example


2. sc description {WindowsServiceName} "This is a worker service example"
 
// {WindowsServiceName} = Unique identifier of the Windows Service. // e.g. WorkerServiceExample


3. sc start {WindowsServiceName}
 
// {WindowsServiceName} = Unique identifier of the Windows Service. // e.g. WorkerServiceExample


4. sc stop {WindowsServiceName}
 
// {WindowsServiceName} = Unique identifier of the Windows Service. // e.g. WorkerServiceExample
