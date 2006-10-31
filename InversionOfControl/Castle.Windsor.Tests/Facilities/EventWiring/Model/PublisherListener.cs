// Copyright 2004-2006 Castle Project - http://www.castleproject.org/
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Castle.Facilities.EventWiring.Tests.Model
{
	using System;

	public class PublisherListener
	{
		private object _sender;
		private bool _listened;

		public event PublishOneEventHandler Event1;

		public PublisherListener()
		{
		}

		public void OnPublish(object sender, EventArgs e)
		{
			_sender = sender;
			_listened = true;
		}

		public void Trigger1()
		{
			Event1(this, new EventArgs());
		}

		public bool Listened
		{
			get { return _listened; }
		}

		public object Sender
		{
			get { return _sender; }
		}
	}
}