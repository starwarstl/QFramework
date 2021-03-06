/****************************************************************************
 * Copyright (c) 2017 xiaojun@putao.com
 * Copyright (c) 2017 liangxie
****************************************************************************/

namespace QFramework
{
	using UnityEngine;

	[QMonoSingletonPath("[Event]/QMsgCenter")]
	public partial class QMsgCenter : MonoBehaviour, ISingleton
	{
		public static QMsgCenter Instance
		{
			get { return QMonoSingletonProperty<QMsgCenter>.Instance; }
		}

		public void OnSingletonInit()
		{

		}

		public void Dispose()
		{
			QMonoSingletonProperty<QMsgCenter>.Dispose();
		}

		void Awake()
		{
			DontDestroyOnLoad(this);
		}

		public void SendMsg(QMsg tmpMsg)
		{
			// Framework Msg
			switch (tmpMsg.GetMgrID())
			{
				case QMgrID.UI:
					QUIManager.Instance.SendMsg(tmpMsg);
					return;
				case QMgrID.Audio:
					AudioManager.Instance.SendMsg(tmpMsg);
					return;
				case QMgrID.PCConnectMobile:
					PCConnectMobileManager.Instance.SendMsg(tmpMsg);
					return;
			}

			// ForwardMsg(tmpMsg);
		}
	}
}