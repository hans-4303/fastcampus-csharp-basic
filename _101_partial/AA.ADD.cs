﻿using System;

namespace _101_partial
{
    /// <summary>
    /// AA 클래스를 부분 별로 나누어 처리: 필드 값을 더하기
    /// </summary>
    public partial class AA
    {
        public void ADD()
        {
            Console.WriteLine("{0} + {1} = {2}", num, num, (num + num));
        }
    }
}
