using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class TalkManager : MonoBehaviour
{
    /* 캐릭터 표정 Sprite */
    public Sprite player1;
    public Sprite player2;
    public Sprite player3;
    public Sprite player4;
    public Sprite player5;
    public Sprite player6;
    public Sprite player7;
    public Sprite player8;
    public Sprite player9;
    public Sprite player10;
    public Sprite player11;
    public Sprite player12;
    public Sprite player13;
    public Sprite player14;
    public Sprite player15;
    public Sprite player16;

    public Sprite ghost1;
    public Sprite ghost2;
    public Sprite ghost3;
    public Sprite ghost4;
    public Sprite ghost5;
    public Sprite ghost6;
    public Sprite ghost7;
    public Sprite ghost8;
    public Sprite ghost9;
    public Sprite ghost10;
    public Sprite ghost11;
    public Sprite ghost12;
    public Sprite ghost13;
    public Sprite ghost14;
    public Sprite ghost15;

    public Sprite ribbon1;
    public Sprite ribbon2;
    public Sprite ribbon3;
    public Sprite ribbon4;
    public Sprite ribbon5;

    public Sprite cap1;
    public Sprite cap2;
    public Sprite cap3;
    public Sprite cap4;
    public Sprite cap5;
    public Sprite cap6;
    public Sprite cap7;
    public Sprite cap8;

    public Sprite glass1;
    public Sprite glass2;
    public Sprite glass3;
    public Sprite glass4;
    public Sprite glass5;
    public Sprite glass6;
    public Sprite glass7;

    public Sprite Reaper1;
    public Sprite Reaper2;

    /* 딕셔너리는 삭제하기 */
    Dictionary<int, string[]> talkData;

    /* 대사 다이얼로그 저장 JSON파일 */
    JObject jObject;

    void Awake()
    {
        /* JSON파일 읽어오기*/
        string filePath = Application.dataPath + "/DialogData/Dialog_WithGhost.json";
        string data = System.IO.File.ReadAllText(filePath);

        jObject = JObject.Parse(data);
    }

    void GenerateData()
    {
        talkData.Add(1, new string[] { "어?", "여기가...어디지?" });

        talkData.Add(2, new string[]
        {
            "!!",
            "너, 사람이야?",
            "흠...",
            "아무렴 어때! 네가 날 도와주면 되겠다!",
            "???",
            "사실 말이야, 엄청 수상한 문을 발견했거든.",
            "그게 아마 여기서 나가는 문인 것 같아서 열려고 했는데, \n그대로 몸이 통과하는 거 있지!",
            "그래서 방금 생각해낸 게 뭐냐면"
        });
        // 귀신이 바위에 빙의
        talkData.Add(3, new string[]
        {
            "쨘!\n이렇게 변한 날 네가 들고 가주는 거야. 어때?",
            "난 수상한 문 위치를 알려주고 넌 날 들어주고!\n서로한테 이득인 일이라구!",
            "엄... 그 바위는 들기 힘들 것 같은데.."
        });

        // 귀신이 바위에서 나옴

        talkData.Add(4, new string[]
        {
            "빙의했는데 놀라지도 않다니...",
            "지금은 바위라서 아무것도 못 보여줬지만,\n빙의하는 물건에 따라 기억도 읽을 수 있어. 나중에 보여줄게.",
            "그래, 그래서...\n저기 벽 중간에 있는 게 나가는 문이지?",
            "저건 가짜 문이야.",
            "진짜 나가는 문은 투명해서 안 보이는데,\n내가 문 앞에 서서 알려줄게!"
        });

        talkData.Add(5, new string[]
        {
            "그쪽은 가짜 문이래두.",
            "내가 처음 보는 귀신 말을 어떻게 믿겠어?"
        });

        talkData.Add(6, new string[]
        {
            "손잡이가 만져진다.",
            "난 먼저 가있을게!"
        });

        talkData.Add(7, new string[]
        {
            "진짜였네?",
            "헤헿, 앞으로도 나만 믿으라구!",
            "그나저나 여긴 어디야?\n집 안에 들어온 거 같기는 한데...",
            "나도 여기가 어딘지는 몰라! 갇힌 이유도 모르구.\n다만 수상한 문이 있는 위치를 알고만 있을 뿐이야. ",
            "여기서는 이제 현관 밖으로 나가야해!\n따라와!"
        });

        talkData.Add(8, new string[]
        {
            "문이 잠겨있어!",
            "...어? 그럼 어쩌지?",
            "밖에서도 안 열려?"
        });

        talkData.Add(9, new string[]
        {
            "고장난건가?",
            "아, 문고리에 빙의해볼게!\n빙의하면 빙의한 물건의 기억이 보이니까!"
        });

        talkData.Add(10, new string[]
        {
            "이 문 젓가락으로 풀면 열려!",
            "이 방에 젓가락이 있을 것 같진 않아.\n그렇다면,"
        });

        talkData.Add(11, new string[]
        {
            "젓가락 같은 물건을 찾아보자."
        });

        talkData.Add(12, new string[]
        {
            "이 볼펜을 분해해서,",
            "볼펜심을 획득했다.",
            "이거로 열어보자."
        });

        talkData.Add(13, new string[]
        {
            "볼펜심을 잠금장치에 넣자 문이 열린다.",
            "됐다!",
            "오! 다행이다!",
            "이제 현관으로 가볼까?"
        });

        talkData.Add(14, new string[]
        {
            "뭐야.\n열쇠로 여는 쪽이 집 쪽으로 있네?",
            "어...난 맨날 통과해서 다녀서 어떻게 여는지 잘 모르겠어.",
            "열쇠를 찾아야 되나?",
            "물건을 조사하면 내가 빙의해서 기억을 볼게!"
        });

        talkData.Add(1400, new string[]                                       // 현관문을 다시 조사했을 때
        {
            "열쇠를 찾아야 해"
        });

        // 세부조사는 140부터 시작됨. 140은 열쇠를 찾았을 때

        talkData.Add(140, new string[]
        {
            "뭐를 메모하고 있는 거지?"
        });

        talkData.Add(141, new string[]
        {
            "음...피아노를 조사해볼까?"
        });
        talkData.Add(142, new string[]
        {
            "앵무새다!"
        });
        talkData.Add(143, new string[]                  // 앵무새가 열쇠를 물고 피아노 위에 서있는 장면 까지
        {
            "!?",
            "쟤 열쇠 물고 있는거 아니야?"
        });
        talkData.Add(144, new string[]                  // 앵무새가 피아노에 떨어진 장면을 보고
        {
           "아...\n열쇠...피아노 깊숙히 들어갔을 것 같은데...",
           "나한테 맡겨!",
           "귀신이 피아노 안에서 열쇠를 꺼내왔다.",
            "현관문 열쇠를 획득했다.",
           "이제 나가면 되겠다. 그치?"
        });

        talkData.Add(15, new string[]
       {
            "열쇠로 현관문을 열었다.",
            "됐다!"
       });

        talkData.Add(16, new string[]
       {
            "어? 바로 학교잖아?.",
            "응! 이제 여기로 올라가기만 하면 돼.",
            "잠깐만!"
       });

        talkData.Add(17, new string[]
       {
            "잠깐 나 좀 도와주면 안 될까?",
            "무슨 일인데?",
            "2층 귀신들이 내 지우개를 가져갔었는데,\n가지고 놀다가 잃어버렸대.",
           "혼자선 도저히 못 찾겠어서 그런데, 도와줄 수 있니?",
           "걔네들 보고 책임지고 찾아달라고 하면 되지.",
           "걔네들은 3, 4학년 귀신인 걸?",
           "3, 4학년은 무섭단 말이야.",
           "쪼꼬만 것들이 해봤자 뭘 하겠어?",
           "너는 몇 살인데?",
           "엄...몰라...",
           "내 지우개를 찾아주면 딱지 3개 줄게.",
           "딱지?",
           "응. 2층 귀신들을 만났을 때 분명 도움이 될 거야.",
           "둘 다 딱지를 좋아하니깐.",
           "좋아, 열심히 찾아볼게. \n어차피 내가 없으면 얜 할 것도 없거든.",
           "!!!",
           "정말 고마워! 1학년 교실은 내가 찾아볼게.\n너네는 2학년 교실을 살펴봐줘.",
       });
        talkData.Add(18, new string[]
      {
            "지우개가 창문에 맞은 건가?",
      });
        talkData.Add(180, new string[]
        {
            "맞아! 지우개는 여기서 튕겼어!"
        });
        talkData.Add(181, new string[]
      {
            "이건가?"
      });
        talkData.Add(182, new string[]
      {
            "오! 햄버거 빵처럼 생겼다."
      });

        talkData.Add(183, new string[]
     {
            "이렇게 봐서는 지우개인지 모르겠네.\n그래도 혹시 모르니까 챙기자."
     });

        talkData.Add(19, new string[]
      {
            "찾았다!",
            "어디어디?"
      });

        talkData.Add(190, new string[]
        {
            "이게 어떻게 지우개야?",
            "이런 지우개도 있어.\n어렸을 때 음식모양 지우개가 집에 많았거든.",
            "아이스크림 모양도 있고 핫도그 모양도 있고.",
            "우와! 나도 구경시켜 줘!",
            "에이, 몇 년이 지났는데. 지금은 다 잃어버리고 없어.",
            "그래도 이런 지우개 오랜만에 봐서 기분이 이상하기는 하네.",
        });

        talkData.Add(191, new string[]
        {
            "이제 리본 맨 귀신한테 돌려주러 가자.",
        });

        talkData.Add(20, new string[]
        {
            "어떡하지? 1학년 교실에는 없어. 열심히 찾았는데도 안보여...",
            "쨘!",
            "우와! 내 지우개!\n양상추 하나쯤은 없어졌을 줄 알았는데 전부 찾았구나!",
            "정말 고마워. 여기, 아까 말했던 딱지 3개!",
            "딱지 3개를 얻었다.",
            "다음부터는 2층애들이 괴롭히면 너도 같이 싸워.,",
            "이미 귀신인데 더 죽기야 하겠어?",
            "히히. 알았어.",
            "그래도 2층 귀신들 만나서 혼내지는 마.\n가끔 내가 도움 받기도 하거든.",
            "그렇다면야, 뭐...",
            "다들 잘 가! 지우개 찾아준 거 진짜 고마워!",
            "그래, 너도 잘 있어!",
        });

        talkData.Add(200, new string[]
        {
            "2층 가는 길은 내 왼쪽으로 쭉 걸어가면 돼!"
        });

        talkData.Add(201, new string[]
        {
            "훌쩍훌쩍"
        });

        talkData.Add(21, new string[]
        {
            "그러고 보니, 어렸을 때 딱지치기 많이 했는데.",
            "그때 같이 놀았던 애들, 잘 지내고 있으려나?",
            "궁금하면 다시 연락하면 되지.",
            "음... 지금은 만나도 그때처럼 놀지는 못하니까.",
            "이제는 되돌아가지 못하는 시절이여서\n더 행복하고 좋았던 기억으로 남은 거 아닐까?",
        });

        talkData.Add(22, new string[]
        {
            "거기 잠깐!",
            "소지품 검사가 있겠다!"
        });

        talkData.Add(23, new string[]
        {
            "아니! 이건...!\n내가 잃어버렸던 딱지!",
            "뭐야! 훔친 거야?",
            "용서할 수 없어!",
            "아니, 진정하고 얘기좀 들어봐!"
        });

        talkData.Add(24, new string[]
        {
            "뭐야, 이렇게 약한 녀석이 우리 딱지를 훔쳐간 거야?",
            "뭔가 이상하네.",
        });

        talkData.Add(25, new string[]
        {
            "크윽, 우리가 지다니...!",
            "분하다!",
        });

        talkData.Add(26, new string[]
        {
            //"이제 우리 얘기도 들어줄래?",
            "이 딱지는 우리가 훔친 게 아니야.\n1층 귀신이 준거라구!",
            "1층 귀신이?",
            "아!",
            "왜?",
            "이거 내가 저번에 1층에서 잃어버렸던 거야.\n까먹었었어.",
            "...",
            "...",
            "우린 이제 가볼게.\n위로 올라갈 생각이었거든.",
            "위로? 3층도 들르는 거야?",
            "왜?",
            "얘, 사실 3층 귀신이야.",
            "귀신 셋이서 1층, 2층, 3층을 맡아서 \n교실에서 사람이 뭘 하는지 관찰하는 게 우리 일이야.",
            "여긴 살아있는 사람이 오진 않으니깐\n심심해서 2층으로 놀러왔지.",
            "너네가 3층 교실에 들르면,\n나도 같이 올라갔다 올까 해서."
        });

        /* 선택 후 */
        /* 배드엔딩 선택 : 3층을 들르지 않음 */
        talkData.Add(27, new string[]
        {
            "굳이 3층을 들러야 할 필요는 없지?",
            "응. 어차피 수상한 문은 옥상에 있으니깐!",
            "좋은 생각이야! 어차피 3층에도 평범한 물건밖에 없거든.",
            "연필, 지우개, 가방, 보드게임, 단체 사진 같은 거 말이야.",
            "그렇구나.",
            "이제 출발하자. 목적지가 눈앞에 있다구!",
            "다들 잘 가! 너네랑 딱지치기 재밌었어!",
            "안녕!",
            "잘 있어!",
            "안녕!"
        });

        /* 진엔딩 및 노말 엔딩 선택 : 3층에 들름 */
        talkData.Add(28, new string[]
        {
            "3층도 돌아보고 싶어.",
            "하긴,\n거의 10년 동안이나 내려와 있는 건 조금 너무한 거 같기도 하다. ",
            "그런가...\n그래도 너네 데려다 주고 나서 아무 일 없으면 바로 내려올 거야.",
            "그래그래.",
            "둘 다 잘 가!\n너네랑 딱지치기 재밌었어!",
            "잘 있어!",
            "안녕!",
        });

        // 3층에 올라와서
        talkData.Add(29, new string[]
        {
            "여기 진짜 볼 거 없어.",
            "그래도 소개하자면 위쪽이 5학년 교실이고 아래쪽이 6학년 교실이야.",
            "어차피 여긴 더 이상 아무 사람도 안 올 테니까 마음대로 써도 괜찮아.",
            "난 이제 간다?\n나갈 때 알아서 나가면 돼!",
            "그래, 같이 올라와줘서 고마워."
        });

        // 책갈피 발견
        talkData.Add(30, new string[]
        {
            "어! 이거 예전에 잃어버렸던 거잖아?",
            "어렸을 때 잃어 버렸던 걸 지금까지 기억해?",
            "응, 그때 친해지고 싶은 친구가 있었는데\n그 애가 생일선물로 준 거였거든.",
            "나한텐 이게 특별한 물건이야.",
            "그렇게나 좋았었는데 너무 오래되었는지 얼굴은 기억이 안 나네."
        });

        // 사진을 살펴보았을 경우
        talkData.Add(31, new string[]
        {
            "내 6학년 단체 사진이 왜 여기 있지?",
            "어, 이 사진... 잠깐만.",
        });
        talkData.Add(311, new string[]
        {
            "그래, 맞아. 나는...",
            "뭐야?",
            "응?",
            "아....아니! 별거 없었어!",
            "이제 진짜 옥상으로 가면 마지막이네!",
            "그러네.",
            "서로 돕는 사이이긴 하지만 그래도 너 없었으면 여기까지 오기 힘들었을 거야.",
            "이제까지 제대로 도와줘서 고마워.",
            "어....",
            "옥상 가는 길은 이쪽이야!"
        });

        /* 배드엔딩 */
        talkData.Add(32, new string[]
        {
            "저게 내가 말한 문이야!",
            "이제 내가 빙의할 만한 게...",
            "저기 화단에 떨어져 있는 꽃은 어때?",
            "좋아!"
        });
        talkData.Add(320, new string[]
        {
            "이제 준비됐어!",
            "꽃을 들고 문으로 들어가자",
        });
        talkData.Add(321, new string[]
        {
            "어? 잠깐만!",
            "분명히 잘 잡혀 있었는데?",
            "나 못 들어갔어!"
        });
        talkData.Add(322, new string[]
        {
            "우리 성공했어!\n이 꽃밭으로 이어지는 문 이었나봐.",
            "옥상에 꽃도 여기서 따온 건가?"
        });
        talkData.Add(323, new string[]
        {
            "...",
            "어?" ,
            "귀신아..?"
        });


        // 저승사자와 만나다.
        talkData.Add(33, new string[]
        {
            "이제 들어가도 되는가?",
            "누...누구세요?",
            "원래 너를 데려가기로 했던 저승사자다.",
            "네가 경계를 만드는 바람에 바로 저승으로 데려갈 수가 없었어.",
            "이렇게 경계가 다시 열리기도 드문 일인데...\n운이 좋았구나.",
            "경계?",
            "사람이 죽은 후에 자신이 누구였는지 잊게 된다면\n본인이 살던 장소로 구성된 경계를 만들게 되지.",
            "자신이 누군지 다시 알게 된다면\n저승사자가 경계에 들어올 수 있지만,",
            "그런 경우는 흔치 않아.",
            "그럼 너, 기억이 다 난거야?",
            "응... 미안,\n내가 누구인지는 못 말해줄 것 같아.",
            "왜?",
            "살아있을 때 친해지지도 못 했는데 귀신이 되어서야,",
            "그것도 아무 기억도 없는 상태로\n너한테 말을 걸고 같이 나가자고 했던 게 창피해.",
            "게다가 내가 귀신인 상태로 기억될 거잖아?\n그건 싫어!",
            "알았어. 그러면 더 안 물어 볼게.",
            "너 이제 저승 갈 건데 후회할 일 남기면 마음 안 좋잖아.",
            ".... 자네는 산 사람인가, 죽은 사람인가?",
            "그야 당연히 살아있는 사람...",
            "산 사람이기엔 경계에 들어올 수가 없고\n죽은 사람이기엔 귀신의 형태로 변하지 않았으니,",
            "솔직히 어째야 할지 난감하네.",
            "...",
            "게다가 경계에서 나갈 수 있는 통로는 여기,\n이 저승으로 가는 저승문 뿐이야.",
            "저승문으로 지나가게 되면 확실하게 죽게 되니, \n어떻게 할 것인지 잘 생각해보게.",
            "귀신이 저승문으로 들어간 후에 \n경계가 어찌 되는지는 알려지지 않다만...",
            "저기, 잠시만 둘이서 얘기를 나눠도 될까요?",
            "그래, 결심이 서면 다시 나에게 말을 걸도록 하게."
        });

        talkData.Add(34, new string[]
        {
            "있잖아, 넌 어떻게 할 생각이야?"
        });
        // 너랑 같이 갈 생각이야.
        talkData.Add(340, new string[]
        {
            "...어?",
            "경계에 남겨지면 어떻게 될지 모른다고 하니깐...",
            "혼자 남겨지는 것 보다는 너랑 같이 가는 게 더 낫지 않을까?",
            "그렇기는 하지만...\n나랑 같이 간다면 어떻게든 살아날 가능성도 없어지는 거잖아.",
            "진짜 괜찮겠어? 저승문을 지나면 진짜 저승에 가는 거야.",
            "...",
            "나는 솔직히 너가 여기에 남았으면 좋겠어.",
            "무책임한 말이기는 하지만 혹시라도 너가 죽은 게 아니라면",
            "그렇다면, 내가 저승에 가서 경계가 없어지고",
            "너도 이 공간에서 현실로 자연스럽게 나갈 수 있게 되는 게 아닐까?",
            "음... ",
            "여기 오면서 너가 그런 말도 했잖아? ",
            "\"이제는 되돌아가지 못하는 시절이여서 더 행복하고 좋았던 기억으로 남은 것 같다\"",
            "나도 그렇게 너한테 좋았던 추억으로 남고 싶어.",
            "너가 살아있었으면 좋겠어.",
            "경계가 어떻게 될지 모르겠지만...\n저승문으로 가면 진짜로 너가 죽는거잖아."
        });

        /* 노말엔딩 선택 */
        talkData.Add(3400, new string[]
        {
            "그래도 난 너랑 같이 갈래.",
            "여기 있다가 영영 경계에 갇히게 되면 여기선 아무것도 못하게 되잖아.",
            "어차피 죽는 거랑 다름없는 상황이라면 난 너랑 같이 가는 게 더 좋아.",
            "정 그렇다면 알았어...",
        });

        /* 진엔딩 선택 */
        talkData.Add(3401, new string[]
        {
            "...알았어. 여기 남아있을게.",
            "좋아! 너가 꼭 살아남길 바랄게.",
        });

        talkData.Add(341, new string[]
        {
            "좋아! 너가 꼭 살아남길 바랄게.",
            "기왕이면 너가 어릴 때 같이 놀았던 애들처럼\n나를 그렇게 기억해 줬으면 좋겠어...!",
            "응. 그럴게.\n너도 조심해서 가."
        });

        talkData.Add(350, new string[]
        {
            "이제 정했는가.",
            "네 저희 같이 갈 거에요.",
            "그럼 가도록 하지."
        });

        talkData.Add(3500, new string[]
        {
            "...",
            "나도 가자.",
        });

        talkData.Add(351, new string[]
        {
            "이제 정했는가.",
            "네 저는 남아있기로 결정했어요.",
            "그럼 가도록 하지.",
            "꼭 살아남아야 해...! 너를 다시 만나서 즐거웠어.",
            "응. 너도 조심히 가."
        });

        /* 노말 엔딩 */
        talkData.Add(352, new string[]
        {
            "...",
            "어? 누구야...?",
            "쨘!\n나 너랑 같이 여행 다니던 그 귀신이야!",
            "이젠 사람모습으로 바뀌었다구!",
            "너 혹시...\n아까 단체사진에서 봤던, 그...",
            "맞아!",
            "오랜만이다! 너 진짜 6학년때 모습 그대로네?",
            "응! 졸업하자마자 죽었거든."
        });

        /* 진엔딩 */
        talkData.Add(36, new string[]
        {
            "진짜 여기에 갇힌 건가?",
            "...아! 정신이 드니?",
            "응? 내 이름이 들린거 같았는데?",
        });

        talkData.Add(37, new string[]
        {
            "정신이 드니?",
            "엄마?",
            "하이고. 신이 살리셨네. 감사합니다. 감사합니다..."
        });

        talkData.Add(38, new string[]
        {
            "...",
            "정신이 든 곳은 구급차 안이였다.",
            "병원에 도착하고 안정이 된 후에\n나한테 무슨 일이 있었는지 들을 수 있었다.",
            "나는 자취를 하다 오랜만에 부모님 집에 들르는 길에 교통사고를 당했다.",
            "그곳은 10여 년 전에도 교통사고로 사망자가 나온 적 있는 곳이라 한다.",
            "왠지 경계에서 만난 귀신이 생각나,\n혹시 내가 아는 애가 사고를 당했는지 여쭤봤다.",
            "그 애는 내가 5학년 때 같은 반에 전학 왔던 친구라고 하셨다.",
            "교통사고는 우리가족이 이사 간 후의 일이었기 때문에\n내가 충격 받을까봐 그 사실을 얘기해 주지 않으셨다고 하셨다.",
            "그리고 2주 후, 난 병원에서 퇴원했다."
        });
    }

    /* 다이얼로그 ID에 맞춰 대사 진행 */
    public string GetTalk(int id, int talkIndex)
    {        
        JArray items = (JArray)jObject["Dialog"][SaveMemory.Id-1]["Chat"];
        if (items.Count <= SaveMemory.talkIndex)
        {            
            return null;
        }
        else
        {
            return jObject["Dialog"][id-1]["Chat"][talkIndex]["talkData"].ToString();
        }
    }

    public Sprite GetImage(int id, int talkIndex)
    {
        JArray items = (JArray)jObject["Dialog"][SaveMemory.Id-1]["Chat"];
        if (items.Count <= SaveMemory.talkIndex)
        {            
            return null;
        }

        /* JSON으로 받은 변수이름의 Sprite를 반환 */
        string ImageName = jObject["Dialog"][id-1]["Chat"][talkIndex]["ImageData"].ToString();
        System.Type type = GetType();
        FieldInfo info = type.GetField(ImageName);
        if (ImageName == null || ImageName == "")
        {
            return null;
        }
        else
        {
            return (Sprite)info.GetValue(this);
        }
    }
}
