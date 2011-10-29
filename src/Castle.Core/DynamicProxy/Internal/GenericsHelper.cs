﻿// Copyright 2004-2011 Castle Project - http://www.castleproject.org/
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

namespace Castle.DynamicProxy.Internal
{
	using System;
	using System.Diagnostics;
	using System.Linq;
	using System.Reflection;

	public class GenericsHelper
	{
		public static readonly MethodInfo GetAdjustedOpenMethodToken = typeof(GenericsHelper).GetMethods(BindingFlags.Public | BindingFlags.Static).Single();

		/// <summary>
		/// This method works around the bug (?) in Reflection API which causes VerificationException when we load directly token of a generic method which has some of its generic arguments
		/// constrained over type's generic arguments.
		/// </summary>
		/// <param name="declaringType"></param>
		/// <param name="metadataToken"></param>
		/// <returns></returns>
		public static MethodInfo GetAdjustedOpenMethod(Type declaringType, int metadataToken)
		{
			var methods = declaringType.GetMethods(BindingFlags.Public | BindingFlags.Instance);
			var method = methods.Single(m => m.MetadataToken == metadataToken);
			Debug.Assert(method.IsGenericMethodDefinition);
			return method;
		}
	}
}