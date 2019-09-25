using System;
using System.Text;
public static class StringProblems{
    public static void ReverseString(int start, int end, StringBuilder sb){
        int mid = (start + end)/2;
        while(start <= mid){
            char temp = sb[start];
            sb[start] = sb[end];
            sb[end] = temp; 
            start++;
            end--;
        }
    }

    public static string ReverseWordsInString(string s){
        int length = s.Length;
        if(length == 0){return s;}
        StringBuilder sb = new StringBuilder(s);
        ReverseString(0, length - 1, sb);
        int start = 0;
        for(int i = 0; i < length; i++){
            if(sb[i] == ' '){
                ReverseString(start, i - 1, sb);
                start = i + 1;
            }
        }
        ReverseString(start, length - 1, sb);
        return sb.ToString() ;
    }
}
