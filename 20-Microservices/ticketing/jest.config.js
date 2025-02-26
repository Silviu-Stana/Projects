module.exports = {
    globals: {
        'ts-jest': {
            isolatedModules: true,
        },
    },
    transform: {
        '^.+\\.(t|j)sx?$': '@swc/jest',
    },
};
