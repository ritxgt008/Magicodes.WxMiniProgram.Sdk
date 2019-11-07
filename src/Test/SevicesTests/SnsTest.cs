// ======================================================================
// 
//           Copyright (C) 2019-2030 湖南心莱信息科技有限公司
//           All rights reserved
// 
//           filename : SnsTest.cs
//           description :
// 
//           created by 雪雁 at  -- 
//           文档官网：https://docs.xin-lai.com
//           公众号教程：麦扣聊技术
//           QQ群：85318032（编程交流）
//           Blog：http://www.cnblogs.com/codelove/
// 
// ======================================================================

using System;
using System.Threading.Tasks;
using Magicodes.WxMiniProgram.Sdk.Services.Sns;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace Test.SevicesTests
{
    public class SnsTest : TestBase
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly SnsAppService _snsAppService;

        public SnsTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            this._snsAppService = Resolve<SnsAppService>();
        }

        [Fact]
        public async Task JscodeToSession_Test()
        {
            //登录凭证校验Code请自己从小程序开发工具中获取
            //wx.login({
            //    success: function(res) {
            //        if (res.code)
            //        {
            //            console.log(res.code)
            //        }
            //    }
            //})
            var result = await _snsAppService.JscodeToSession("001p0EE41cBD6L1KWLE41CZGE41p0EEl");
            _testOutputHelper.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(result));
            result.IsSuccess().ShouldBe(expected: true);
            result.OpenId.ShouldNotBeNullOrWhiteSpace();
        }
    }
}