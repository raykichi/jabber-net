/* --------------------------------------------------------------------------
 *
 * License
 *
 * The contents of this file are subject to the Jabber Open Source License
 * Version 1.0 (the "License").  You may not copy or use this file, in either
 * source code or executable form, except in compliance with the License.  You
 * may obtain a copy of the License at http://www.jabber.com/license/ or at
 * http://www.opensource.org/.  
 *
 * Software distributed under the License is distributed on an "AS IS" basis,
 * WITHOUT WARRANTY OF ANY KIND, either express or implied.  See the License
 * for the specific language governing rights and limitations under the
 * License.
 *
 * Copyrights
 * 
 * Portions created by or assigned to Cursive Systems, Inc. are 
 * Copyright (c) 2002 Cursive Systems, Inc.  All Rights Reserved.  Contact
 * information for Cursive Systems, Inc. is available at http://www.cursive.net/.
 *
 * Portions Copyright (c) 2002 Joe Hildebrand.
 * 
 * Acknowledgements
 * 
 * Special thanks to the Jabber Open Source Contributors for their
 * suggestions and support of Jabber.
 * 
 * --------------------------------------------------------------------------*/
using System;

using NUnit.Framework;
using bedrock.collections;
using bedrock.util;

namespace test.bedrock.collections
{
    /// <summary>
    ///    Summary description for TemplateTest.
    /// </summary>
    [RCS(@"$Header$")]
    [TestFixture]
    public class ByteStackTest
    {
        private System.Text.Encoding ENC = System.Text.Encoding.Default;
        public void Test_Main() 
        {
            ByteStack bs = new ByteStack();
            Assertion.AssertEquals(0, bs.Count);
            bs.Push((byte) 'a');
            Assertion.AssertEquals(1, bs.Count);
            byte b = bs.Pop();
            Assertion.AssertEquals(b, (byte)'a');
            Assertion.AssertEquals(0, bs.Count);
        }
        public void Test_Empty()
        {
            ByteStack bs = new ByteStack();
            byte[] buf = bs;
            Assertion.AssertEquals(0, buf.Length);
        }
        public void Test_Init()
        {
            ByteStack bs = new ByteStack(ENC.GetBytes("foo"));
            Assertion.AssertEquals("foo", bs.ToString());
            bs.Push((byte) 't');
            Assertion.AssertEquals("foot", bs.ToString());
            bs = new ByteStack(ENC.GetBytes("f"));
            bs.Push((byte) 't');
            Assertion.AssertEquals("ft", bs.ToString());
        }
        public void Test_Growth()
        {
            ByteStack bs = new ByteStack(4);
            
            bs.Push((byte) 'b');
            Assertion.AssertEquals("b", bs.ToString());
            bs.Push((byte) 'c');
            Assertion.AssertEquals("bc", bs.ToString());
            bs.Push((byte) 'd');
            Assertion.AssertEquals("bcd", bs.ToString());
            bs.Push((byte) 'e');
            Assertion.AssertEquals("bcde", bs.ToString());
            bs.Push((byte) 'b');
            Assertion.AssertEquals("bcdeb", bs.ToString());
            bs.Push((byte) 'c');
            Assertion.AssertEquals("bcdebc", bs.ToString());
            bs.Push((byte) 'd');
            Assertion.AssertEquals("bcdebcd", bs.ToString());
            bs.Push((byte) 'e');
            Assertion.AssertEquals("bcdebcde", bs.ToString());
            bs.Push((byte) 'b');
            bs.Push((byte) 'c');
            bs.Push((byte) 'd');
            bs.Push((byte) 'e');
            bs.Push((byte) 'b');
            bs.Push((byte) 'c');
            bs.Push((byte) 'd');
            bs.Push((byte) 'e');
            Assertion.AssertEquals("bcdebcdebcdebcde", bs.ToString());
        }
    }
}