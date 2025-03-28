# NT-BOT

## 项目依赖
* `git` 拉取 `http://47.109.22.188:3000/git/NT-BOT/NT-CORE.git` 
* `BotService` 依赖于 `Lagrange.Core` 项目

## 项目配置
* 运行 `Lagrange.Core.OneBot` 项目，会生成服务端进行扫码登陆
* 服务端配置参考 [OneBot - 文档](https://lagrangedev.github.io/Lagrange.Doc/Lagrange.OneBot/)
* `Bot` 端的配置需要同服务端链接一致

## 项目实现
* 具体查看 `Program` 启动

## 项目原理
* 通过伪装 `NTQQ` 客户端，拦截消息，通过服务端转发
* 客户端收到消息，解包然后实现自己的业务

## 最新
* 本来想写一个小小的机器人修仙，但是烂尾了，想摆烂了..
* demo也写得烂，见谅

## 其它
* 消息段解包引用了  `Sora` 的结构体
* 变更了 `Lagrange.Core.OneBot` 中的生成二维码，详情查看上文项目依赖中的 `QrCodeHelper` 类
* 跟踪于 [Issue](https://github.com/LagrangeDev/Lagrange.Core/issues/732)

* ```c#

    internal static void Output(string text, bool compatibilityMode)
    {
    const int threshold = 180;

     var barcodeWriter = new BarcodeWriter<QRCode>
     {
         Format = BarcodeFormat.QR_CODE,
         Options = new QrCodeEncodingOptions
         {
             Width = 22,
             Height = 22,
             Margin = 1
         }
     };

     var image = barcodeWriter.WriteAsImageSharp<Rgba32>(text);

     int[,] points = new int[image.Width, image.Height];

     for (var i = 0; i < image.Width; i++)
     {
         for (var j = 0; j < image.Height; j++)
         {
             var color = image[i, j];
             if (color.B <= threshold)
             {
                 points[i, j] = 1;
             }
             else
             {
                 points[i, j] = 0;
             }
         }
     }

     for (var i = 0; i < image.Width; i++)
     {
         for (var j = 0; j < image.Height; j++)
         {
             if (points[i, j] == 0)
             {
                 Console.BackgroundColor = ConsoleColor.Black;
                 Console.ForegroundColor = ConsoleColor.Black;
                 Console.Write("  ");
                 Console.ResetColor();
             }
             else
             {
                 Console.BackgroundColor = ConsoleColor.White;
                 Console.ForegroundColor = ConsoleColor.White;
                 Console.Write("  ");
                 Console.ResetColor();
             }
         }
         Console.Write("\n");
     }

     if (compatibilityMode)
     {
         Console.WriteLine("Please scan this QR code from a distance with your smart phone.\nScanning may fail if you are too close.");
     }
}
```
