using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
                          디스코드 베리TV 도우미 봇 소스코드
                          소스코드 최종버전 : Ver.2017-06-08
                          소스 및 프로그램 제작 : 쿤☆롬롬 (아프리카TV)
*/

namespace VeryBot
{
    class MyBot
    {
        DiscordClient discord;
        
        public MyBot()
        {
            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            // 봇 실행 커맨드 입력
            discord.UsingCommands(x =>
            {
                x.PrefixChar = '@';
                x.AllowMentionPrefix = true;
            });
            
            var commands = discord.GetService<CommandService>();

            // @[커맨드] 입력시 출력될 텍스트
            commands.CreateCommand("명령어")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("제가 학습한 명령어는 다음과 같아요 / 모든 명령어는 '@' 키로 작동해요");
                    await e.Channel.SendMessage("[ @방송시간 ]         [ @방송국주소 ]       [ @방송보기 ]           [ @고정멤버 ]");
                    await e.Channel.SendMessage("[ @봇정보 ]");
                });

            commands.CreateCommand("방송시간")
                .Do(async (e) =>
               {
                   await e.Channel.SendMessage("저는 매일 밤 9시에서 10시 사이에 방송을 시작하고있어요!");
                   await e.Channel.SendMessage("그러니 절 보러와줬으면 좋겠어요 >_<");
               });

            commands.CreateCommand("방송국주소")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("내 방송국은 http://afreecatv.com/dlackdhr12 여기에요!");
                    await e.Channel.SendMessage("많이많이 찾아와줘요!");
                });

            commands.CreateCommand("방송보기")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("http://play.afreecatv.com/dlackdhr12 여기서 볼수있어요!");
                });

            commands.CreateCommand("고정멤버")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("2017년 6월 8일 현재 [ 모집중 ]");
           //       await e.Channel.SendMessage("2017년 월 일 현재 [ 모집종료 ]");
                    await e.Channel.SendMessage("베리티비에서 고정멤버를 구하고 있어요!");
                    await e.Channel.SendMessage("나이제한 : 17살 이상");
                    await e.Channel.SendMessage("인원 : 4명 ~ 8명");
                    await e.Channel.SendMessage("http://live.afreecatv.com:8079/app/index.cgi?szBoard=read_bbs&szBjId=dlackdhr12&nStationNo=6771365&nBbsNo=0&nTitleNo=21990394&nRowNum=&nPageNo=");
                    await e.Channel.SendMessage("자세한 사항은 링크를 참조해주세요");
                });

                   commands.CreateCommand("봇정보").Do(async (e) =>
                   {
                   await e.Channel.SendMessage("베리TV 도우미 봇 - 베리TV 디스코드방에 계신 분들을 위해 개발된 봇입니다.");
                   await e.Channel.SendMessage("개발언어 : Visual C#");
                   await e.Channel.SendMessage("최종버전 : Ver.2017-06-08 / 봇 업데이트 내역보기 : @업데이트");
                   await e.Channel.SendMessage("문의     [    Discord(디스코드) : ROMROM#0588    ]");
                   });

            
            commands.CreateCommand("업데이트").Do(async (e) =>
            {
                await e.Channel.SendMessage("--------------------------최근 업데이트 내역---------------------------------");
                await e.Channel.SendMessage("2017-06-06 : 베리TV 도우미 개발");
         //     await e.Channel.SendMessage("");
                await e.Channel.SendMessage("-----------------------------------------------------------------------------");
                await e.Channel.SendMessage("");
            });

            //      await discord.SetGame("try !help");

            // 디스코드 봇 로그인토큰           - 이 부분은 실제 사용중인 봇 토큰이므로 실제사용할때에는 본인의 봇 토큰을 넣어주세요
            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("MzIxMTg4NDIzMzc1MjU3NjAx.DBaZjQ.SqbIvWJV9gSVxsxvBR2TR71hNjQ", TokenType.Bot);
            });
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}