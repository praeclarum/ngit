/*
This code is derived from jgit (http://eclipse.org/jgit).
Copyright owners are documented in jgit's IP log.

This program and the accompanying materials are made available
under the terms of the Eclipse Distribution License v1.0 which
accompanies this distribution, is reproduced below, and is
available at http://www.eclipse.org/org/documents/edl-v10.php

All rights reserved.

Redistribution and use in source and binary forms, with or
without modification, are permitted provided that the following
conditions are met:

- Redistributions of source code must retain the above copyright
  notice, this list of conditions and the following disclaimer.

- Redistributions in binary form must reproduce the above
  copyright notice, this list of conditions and the following
  disclaimer in the documentation and/or other materials provided
  with the distribution.

- Neither the name of the Eclipse Foundation, Inc. nor the
  names of its contributors may be used to endorse or promote
  products derived from this software without specific prior
  written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND
CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES,
INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES
OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR
CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT
NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT,
STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF
ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

using System.Text;
using NGit;
using NGit.Util;
using Sharpen;

namespace NGit
{
	/// <summary>
	/// A line in a Git
	/// <see cref="Config">Config</see>
	/// file.
	/// </summary>
	internal class ConfigLine
	{
		/// <summary>The text content before entry.</summary>
		/// <remarks>The text content before entry.</remarks>
		internal string prefix;

		/// <summary>The section name for the entry.</summary>
		/// <remarks>The section name for the entry.</remarks>
		internal string section;

		/// <summary>Subsection name.</summary>
		/// <remarks>Subsection name.</remarks>
		internal string subsection;

		/// <summary>The key name.</summary>
		/// <remarks>The key name.</remarks>
		internal string name;

		/// <summary>The value.</summary>
		/// <remarks>The value.</remarks>
		internal string value;

		/// <summary>The text content after entry.</summary>
		/// <remarks>The text content after entry.</remarks>
		internal string suffix;

		internal virtual ConfigLine ForValue(string newValue)
		{
			ConfigLine e = new ConfigLine();
			e.prefix = prefix;
			e.section = section;
			e.subsection = subsection;
			e.name = name;
			e.value = newValue;
			e.suffix = suffix;
			return e;
		}

		internal virtual bool Match(string aSection, string aSubsection, string aKey)
		{
			return EqIgnoreCase(section, aSection) && EqSameCase(subsection, aSubsection) && 
				EqIgnoreCase(name, aKey);
		}

		internal virtual bool Match(string aSection, string aSubsection)
		{
			return EqIgnoreCase(section, aSection) && EqSameCase(subsection, aSubsection);
		}

		private static bool EqIgnoreCase(string a, string b)
		{
			if (a == null && b == null)
			{
				return true;
			}
			if (a == null || b == null)
			{
				return false;
			}
			return StringUtils.EqualsIgnoreCase(a, b);
		}

		private static bool EqSameCase(string a, string b)
		{
			if (a == null && b == null)
			{
				return true;
			}
			if (a == null || b == null)
			{
				return false;
			}
			return a.Equals(b);
		}

		public override string ToString()
		{
			if (section == null)
			{
				return "<empty>";
			}
			StringBuilder b = new StringBuilder(section);
			if (subsection != null)
			{
				b.Append(".").Append(subsection);
			}
			if (name != null)
			{
				b.Append(".").Append(name);
			}
			if (value != null)
			{
				b.Append("=").Append(value);
			}
			return b.ToString();
		}
	}
}