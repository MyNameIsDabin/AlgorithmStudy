function solution(arr)
{
    var prev = arr[0];
    var answer = [prev];

    arr.forEach(el => {
        if (prev !== el) {
            answer.push(el);
            prev = el;
        }
    });

    return answer;
}