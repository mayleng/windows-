1.这是一个Windows的系统服务程序

2.系统服务的程序编译完成后，不能点击运行，直接点击生成就行。


3.服务编译完代码后更改部分属性如下：

编写完服务代码后，右键“添加安装程序”时项目中生成安装组件ServiceProcessInstaller 和 ServiceInstaller。选中“serviceInstaller1” 控件，F4打开属性面板。有如下属性。

Description 服务程序的描述信息
DisplayName 服务程序显示的名称
StartType 指定如何启动服务
Manual 服务安装后，必须手动启动
Automatic 每次计算机重新启动时，服务都会自动启动
Disabled 服务无法启动

选中“serviceProcessInstaller1” 控件，F4打开属性面板：

将 serviceProcessInstaller 类的 Account 属性改为 LocalSystem。这样，不论是以哪个用户登录的系统，服务总会启动。


4.创建一个新的系统服务默认只有两个方法：（服务启动和服务停止）

//服务启动 （在“服务控制管理器”(SCM) 向服务发送“开始”命令时，或者在操作系统启动时（对于自动启动的服务）。 指定服务启动时采取的操作。）
不要使用构造函数来执行处理，应为OnStart。 使用OnStart来处理你的服务的所有初始化。 构造函数只调用一次，使用完onstop
后，不会再调用构造函数，但是会调用onstart。
protected override void OnStart(string[] args){
   
   }


//服务停止
protected override void OnStop(){

    }

还有其他事件方法


//系统即将关闭执行代码）（仅当操作系统时已关闭，未在计算机处于关闭状态时，将发生此事件。）
protected override void OnShutdown(){
  base.OnShutdown();
   }

// 服务暂停
protected override void OnPause(){

   }

//服务恢复执行代码（“服务控制管理器”(SCM) 将“继续”命令发送到服务时运行。 指定要在服务暂停后恢复正常功能时采取的操作。）OnContinue 需要时重写CanPauseAndContinue属性是true。  跟onpause是一对方法
protected override void OnContinue(){
            base.OnContinue();
      }
OnPause 并OnContinue通常实现来执行较少的处理。

//获取或设置指示服务是否可以暂停并再继续的值
public bool CanPauseAndContinue { get; set; }


// 系统电源状态改变
protected override bool OnPowerEvent(PowerBroadcastStatus powerStatus)
     {
            return base.OnPowerEvent(powerStatus);
   }
OnPowerEvent 需要时重写CanHandlePowerEvent属性是true。



5.可以使用 .NET Framework 在 Visual Studio 中创建两种服务类型。 

作为进程中唯一服务的服务将分配类型 Win32OwnProcess。 
与其他服务共享进程的服务将分配类型 Win32ShareProcess。 


6.项目中只创建一个service时，才能被探针识别。否则无法识别。



























