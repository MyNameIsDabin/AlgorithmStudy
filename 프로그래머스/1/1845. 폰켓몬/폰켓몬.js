function solution(nums) {
    const pickCount = nums.length / 2;
    const map = {};
    nums.forEach(el => {
        map[el] = true;
    });
    return Math.min(pickCount, Object.keys(map).length);
}