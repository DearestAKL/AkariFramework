using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinaXGameKit.Drama.BP;
using TinaXGameKit.Drama;
using UnityEngine.UI;
using System;
using DG.Tweening;
using libx;

namespace Akari
{
    public class DialogueTest : MonoBehaviour
    {
        private DialoguePlayer mPlayer;
        private enum Status
        {
            /// <summary>
            /// 选择播放的蓝图
            /// </summary>
            select,
            /// <summary>
            /// 显示内容对话
            /// </summary>
            content,
            /// <summary>
            /// 显示选项
            /// </summary>
            choose,
            /// <summary>
            /// 播放结束
            /// </summary>
            finish,
        }
        
        /// <summary>
        /// 当前状态记录
        /// </summary>
        private Status mCurStatus = Status.select;
        private string mTitle;
        private string mContent;
        private string mSpeaker;

        public DialogueBluePrint asset;
        public Text txtContent;
        public Text txtSpeaker;

        public Button[] buttons;
        public Button btnNext;

        public Image imgAvatar;

        private void Awake()
        {
            btnNext.onClick.AddListener(OnNext);
            mPlayer = new DialoguePlayer();

            mPlayer.OnChoose = (data) =>
            {
                mTitle = data.GetTitle();
                mContent = "";
                mSpeaker = data.GetSpeaker();
                //按钮列表
                var chooseList = data.GetChooseList();
                int index = 0;
                foreach (var item in chooseList)
                {
                    buttons[index].gameObject.SetActive(true);
                    buttons[index].GetComponentInChildren<Text>().text = item;
                    buttons[index].onClick.RemoveAllListeners();
                    buttons[index].onClick.AddListener(() =>
                    {
                        mPlayer.NextWithString(item);
                    });
                    index++;
                }
                if (chooseList.Length < buttons.Length)
                {
                    for (int i = chooseList.Length; i < buttons.Length; i++)
                    {
                        buttons[i].gameObject.SetActive(false);
                    }
                }
                mCurStatus = Status.choose;
                Select();
            };

            mPlayer.OnContent = (data) =>
            {
                mTitle = "";
                mContent = data.GetContent();
                mSpeaker = data.GetSpeaker();

                var textBind = data.GetTextBind();
                for (int i = 0; i < textBind.Length; i++)
                {
                    if(textBind[i].key == "imgAvatar")
                    {
                        //imgAvatar.sprite = Assets.LoadAsset(path, typeof(Sprite));
                    }
                }

                mCurStatus = Status.content;
                Select();
            };

            mPlayer.OnFinish = (data) =>
            {
                mCurStatus = Status.finish;
                mContent = data;
                Select();
            };

            mPlayer.PlayDialogue(asset);
        }

        private void Select()
        {
            switch (mCurStatus)
            {
                case Status.select:
                    Draw_select();
                    break;
                case Status.content:
                    Draw_Content();
                    break;
                case Status.choose:
                    Draw_Choose();
                    break;
                case Status.finish:
                    Draw_Finish();
                    break;
            }
        }

        private void Draw_select()
        {

        }

        private void Draw_Content()
        {
            txtContent.DOText(mContent, 1F);
            txtSpeaker.text = mSpeaker;
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].gameObject.SetActive(false);
            }
        }

        private void Draw_Choose()
        {
            txtContent.DOText(mTitle, 1F);
            txtSpeaker.text = mSpeaker;

        }

        private void Draw_Finish()
        {

        }

        private void OnNext()
        {
            mPlayer.Next();
        }
    }
}
