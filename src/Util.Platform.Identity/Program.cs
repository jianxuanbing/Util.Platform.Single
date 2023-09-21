using Util.Platform.Identity;

//����WebӦ�ó���������
var builder = WebApplication.CreateBuilder( args );

//���ÿ�����
builder.AddControllers();

//Util������������
builder.AddUtil();

//���ù�����Ԫ
builder.AddIdentityUnitOfWork();

//������ݱ�ʶ����
builder.AddIdentity();

//���������֤������
builder.AddIdentityServer();

//������֤
builder.Services.AddAuthentication();

//����Cors
builder.AddCors();

//����ת��ͷ��
builder.AddForwardedHeaders();

//����Http��־
builder.AddHttpLogging();

//����WebӦ�ó���
var app = builder.Build();

//===== ��������ܵ� =====//

//����Http��־��¼
app.UseHttpLogging();

//�����쳣ҳ
app.UseCustomExceptionPage();

//���û�·��
app.UsePathBase();

//����ת��ͷ��
app.UseForwardedHeaders();

//����Cors
app.UseCors( "cors" );

//���þ�̬�ļ�
app.UseStaticFiles();

//���ñ��ػ�
app.UseRequestLocalization();

//����Cookie����
app.UseCookiePolicy();

//����·��
app.UseRouting();

//������ݷ�����
app.UseCustomIdentityServer();

//������֤
app.UseAuthentication();

//�����⻧
app.UseTenant();

//������Ȩ
app.UseAuthorization();

//���ÿ�����
app.MapDefaultControllerRoute();

try {
    //����Ӧ��
    app.Logger.LogInformation( "׼������Ӧ�� ..." );
    await app.RunAsync();
    return 0;
}
catch ( Exception ex ) {
    app.Logger.LogCritical( ex, "Ӧ������ʧ�� ..." );
    return 1;
}
finally {
    Serilog.Log.CloseAndFlush();
}