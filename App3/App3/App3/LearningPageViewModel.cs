using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace App3
{
    public class LearningPageViewModel : ObservableObject
    {
        public event EventHandler TextChanged;
        private object _playLock = new object();

        private string articleHtmlFormat;

        public string ArticleHtmlFormat
        {
            get { return articleHtmlFormat; }
            set
            {
                articleHtmlFormat = value;
                if (TextChanged != null)
                {
                    TextChanged.Invoke(this, null);
                }

                NotifyPropertyChanged();
            }
        }
        
        public void ShowCorrectAction(string param)
        {
            switch (param.Substring(0, 1))
            {
               
            }
        }

        public LearningPageViewModel()
        {
            articleHtmlFormat = ArticleHtml();
        }
        
        public string ArticleHtml()
        {
           var articleHtml = @"<html>
<head>
  <meta name='viewport' content='width=device-width,initial-scale=1,maximum-scale=1' />
</head>
<body class='avat'>
    <style>
    
.avat {
    font-family: sans-serif;
    font-size: 15px;
    text-align: justify;
}

.title {
    font-size: 16px;
}

.red {
  color: red;
}

.word {
  font-weight: bold;
}
.phrase {
  text-decoration: underline;
}
    </style>
    <script type='text/javascript'>
               function invokeCSCode(data) {
        	
           var els = document.getElementsByClassName('red');
             while (els[0]) {
                els[0].classList.remove('red');
              }

            invokeCSharpAction(data);
            var my_element = document.querySelector('[sentenceId=' + data + ']');
             my_element.scrollIntoView({
                            behavior: 'smooth',
                block: 'center',
                inline: 'nearest'
                          });

            var sentenceName = my_element.getAttribute('sentenceName');

            if (data[0] === 's')
            {
                var x = document.querySelectorAll('[sentenceName=' + sentenceName + ']');
                var i;
                for (i = 0; i < x.length; i++)
                {
                    x[i].classList.add('red');
                }
            }
            else
            {
                my_element.classList.add('red');
            }

        }

function scrollToPosition(data) {
        	
          	var els = document.getElementsByClassName('red');
             while (els[0]) {
                els[0].classList.remove('red');
              }

            var my_element = document.querySelector('[sentenceId=' + data + ']');
             my_element.scrollIntoView({
                            behavior: 'smooth',
                block: 'center',
                inline: 'nearest'
                          });

            var sentenceName = my_element.getAttribute('sentenceName');

            if (data[0] === 's')
            {
                var x = document.querySelectorAll('[sentenceName=' + sentenceName + ']');
                var i;
                for (i = 0; i < x.length; i++)
                {
                    x[i].classList.add('red');
                }
            }
            else
            {
                my_element.classList.add('red');
            }

        }
    </script>
 ";


             var spans = FindAllClickableSpans(Article()).ToArray();

             for (int i = 0; i < spans.Length; i++)
             {
                 articleHtml += "<span ";
                 articleHtml += " sentenceId='" + i + "' onclick='javascript: invokeCSCode(\"" + i + "\");' sentenceName='" + 's' + "'>" + spans[i] + "</span>";
             }

             /*articleHtml += "<span ";
             articleHtml += " sentenceId='" + 1 + "' onclick='javascript: invokeCSCode(\"" + 1 + "\");' sentenceName='" + 1 + "'>" + "TESTETSTETSTSTS:" + "</span>";*/

             
            articleHtmlFormat = articleHtml;
             
             return articleHtmlFormat;
        }

        public string Article()
        {
           return @"Excuse me,” said a girl, “you look lost. Can I help you?”\“Yes, please. Thank you. I wanted to go to the museum but I don't know where it is.”\“Oh, the museum is near the train station. Go down here, take the second turning on the left. Go past the post office and it's on the right.\The young man didn't understand, so he looked at the girl, then at the map and then at the girl again.\“I'm sorry, can you repeat that, please?”\The girl smiles and says:\“Yes, go down here, take the second turning on the left. Go past the post office and it's on the right.\Where are you from?” she asks him.\“I am from Greece, my name is Kostas.\What is your name?”\“I am Emily, nice to meet you, Kostas.\“Pleased to meet you, too.\Can you please show me where the museum is?”\Emily says: “OK, Kostas, I am going to the post office, I can show you.\Emily and Kostas walk to the museum together and Emily shows Kostas around. “Look, Kostas, there is a town hall, it is a very old building. And there is a market over there. You can buy some fresh fruit and vegetables there. And it's not expensive.\Oh, wait! Don't cross the road here, there is a pedestrian crossing!”, shouts Emily.\She knows that cars go very fast here, it is a main road and traffic is very bad in the afternoon.\“I'm sorry”, says Kostas. “I come from a small village in Greece and we don't have any traffic lights there, you know?\Listen, Emily, is there a bank near here?”\“Yes, there is. It's opposite the museum. Why?”\“I need some money. Is there a cash machine, too?”\“I think so.” says Emily.\They arrive at the bank and Emily waits for Kostas outside.\“Emily, how can we get to the nearest coffee shop?” asks Kostas.\“Well, I think there is a nice coffee shop on the corner of this street. Why?”\Kostas smiles and answers: “I would like to take you for a cup of coffee.”\“But what about your museum?” says Emily, „if you go straight on you can't miss it. It's not far from here.”\“I know but you helped me and showed me your town. Please let's go for a coffee, ok?”\“Oh, that's nice of you, thank you. Let's go for a coffee then. The coffee shop is just around the corner.”";
        }
        
        private IEnumerable<string> FindAllClickableSpans(string article)
        {
            IList<ClickableText> clickableSpans = new List<ClickableText>();
            article = article.ToLower();

            var changedArticle = article.Split('.');

            return changedArticle;
            
        }



    }
    public class ClickableText
    {
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        public string Text { get; set; }
        public int Id { get; set; }
        public bool IsWord { get; set; }
        public bool IsPhrase { get; set; }
        public int LineNumber { get; set; }
        public bool IsTitle { get; set; }
    }
}