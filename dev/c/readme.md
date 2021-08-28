[solve_dpend.c](solve_dpend.c) was created by [Michael S. Wheatland](http://www.physics.usyd.edu.au/~wheat/) and is released (with permission of the original author) under the MIT license. See his website [The Double Pendulum](http://www.physics.usyd.edu.au/~wheat/dpend_html/) for more information.

## Linux

```bash
gcc solve_dpend.c -o solve_linux -lm
```

```
command line arguments: TMIN, TMAX, TH10, W10, TH20, W20, NSTEP
```

```bash
./solve_linux 0.0 10.0 90.0 0.00 -10.0 0.0 1000 > solve_linux.txt
```

## Windows

Assuming you have Visual Studio installed, run `vcvars64.bat` to set-up your environment variables. 

For more information see: [Use the Microsoft C++ toolset from the command line](https://docs.microsoft.com/en-us/cpp/build/building-on-the-command-line?redirectedfrom=MSDN&view=msvc-160)

```bash
"C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\VC\Auxiliary\Build\vcvars64.bat"
```

```bash
cl solve_dpend.c /link /out:solve_windows.exe
```

```
command line arguments: TMIN, TMAX, TH10, W10, TH20, W20, NSTEP
```

```bash
solve_windows.exe 0.0 10.0 90.0 0.00 -10.0 0.0 1000 > solve_windows.txt
```

## Output

See all: [output.txt](output.txt)

```
0.000000 1.570796 0.000000 -0.174533 0.000000
0.010010 1.570305 -0.098094 -0.174533 0.000048
0.020020 1.568833 -0.196163 -0.174531 0.000385
0.030030 1.566378 -0.294183 -0.174523 0.001300
0.040040 1.562943 -0.392130 -0.174502 0.003080
0.050050 1.558528 -0.489983 -0.174458 0.006014
...
9.979980 -0.115793 -1.950584 -1.987931 1.523354
9.989989 -0.135224 -1.932051 -1.972023 1.654751
10.000000 -0.154482 -1.916253 -1.954806 1.785180
```