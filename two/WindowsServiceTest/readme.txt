1.����һ��Windows��ϵͳ�������

2.ϵͳ����ĳ��������ɺ󣬲��ܵ�����У�ֱ�ӵ�����ɾ��С�


3.���������������Ĳ����������£�

��д����������Ҽ�����Ӱ�װ����ʱ��Ŀ�����ɰ�װ���ServiceProcessInstaller �� ServiceInstaller��ѡ�С�serviceInstaller1�� �ؼ���F4��������塣���������ԡ�

Description ��������������Ϣ
DisplayName ���������ʾ������
StartType ָ�������������
Manual ����װ�󣬱����ֶ�����
Automatic ÿ�μ������������ʱ�����񶼻��Զ�����
Disabled �����޷�����

ѡ�С�serviceProcessInstaller1�� �ؼ���F4��������壺

�� serviceProcessInstaller ��� Account ���Ը�Ϊ LocalSystem�����������������ĸ��û���¼��ϵͳ�������ܻ�������


4.����һ���µ�ϵͳ����Ĭ��ֻ�����������������������ͷ���ֹͣ��

//�������� ���ڡ�������ƹ�������(SCM) ������͡���ʼ������ʱ�������ڲ���ϵͳ����ʱ�������Զ������ķ��񣩡� ָ����������ʱ��ȡ�Ĳ�������
��Ҫʹ�ù��캯����ִ�д���ӦΪOnStart�� ʹ��OnStart��������ķ�������г�ʼ���� ���캯��ֻ����һ�Σ�ʹ����onstop
�󣬲����ٵ��ù��캯�������ǻ����onstart��
protected override void OnStart(string[] args){
   
   }


//����ֹͣ
protected override void OnStop(){

    }

���������¼�����


//ϵͳ�����ر�ִ�д��룩����������ϵͳʱ�ѹرգ�δ�ڼ�������ڹر�״̬ʱ�����������¼�����
protected override void OnShutdown(){
  base.OnShutdown();
   }

// ������ͣ
protected override void OnPause(){

   }

//����ָ�ִ�д��루��������ƹ�������(SCM) ��������������͵�����ʱ���С� ָ��Ҫ�ڷ�����ͣ��ָ���������ʱ��ȡ�Ĳ�������OnContinue ��Ҫʱ��дCanPauseAndContinue������true��  ��onpause��һ�Է���
protected override void OnContinue(){
            base.OnContinue();
      }
OnPause ��OnContinueͨ��ʵ����ִ�н��ٵĴ���

//��ȡ������ָʾ�����Ƿ������ͣ���ټ�����ֵ
public bool CanPauseAndContinue { get; set; }


// ϵͳ��Դ״̬�ı�
protected override bool OnPowerEvent(PowerBroadcastStatus powerStatus)
     {
            return base.OnPowerEvent(powerStatus);
   }
OnPowerEvent ��Ҫʱ��дCanHandlePowerEvent������true��



5.����ʹ�� .NET Framework �� Visual Studio �д������ַ������͡� 

��Ϊ������Ψһ����ķ��񽫷������� Win32OwnProcess�� 
��������������̵ķ��񽫷������� Win32ShareProcess�� 


6.��Ŀ��ֻ����һ��serviceʱ�����ܱ�̽��ʶ�𡣷����޷�ʶ��



























